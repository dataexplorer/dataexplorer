using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Application.Rows;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.DataTypes.Converters;
using DataExplorer.Domain.DataTypes.Loaders;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Sources.Maps;

namespace DataExplorer.Application.Importers.CsvFiles.Commands
{
    public class ImportCsvFileSourceCommandHandler 
        : ICommandHandler<ImportCsvFileSourceCommand>
    {
        private readonly ISourceRepository _repository;
        private readonly IEventBus _eventBus;
        private readonly IApplicationStateService _stateService;
        private readonly IDataContext _dataContext;
        private readonly ICsvFileDataAdapter _dataAdapter;
        private readonly IDataTypeConverterFactory _converterFactory;
        private readonly IDataLoaderFactory _loaderFactory;
        private readonly IColumnFactory _columnFactory;
        private readonly IColumnRepository _columnRepository;
        private readonly IRowRepository _rowRepository;

        public ImportCsvFileSourceCommandHandler(
            ISourceRepository repository, 
            IEventBus eventBus, 
            IApplicationStateService stateService,
            IDataContext dataContext, 
            ICsvFileDataAdapter dataAdapter, 
            IDataTypeConverterFactory converterFactory,
            IDataLoaderFactory loaderFactory,
            IColumnFactory columnFactory,
            IColumnRepository columnRepository, 
            IRowRepository rowRepository)
        {
            _repository = repository;
            _eventBus = eventBus;
            _stateService = stateService;
            _dataContext = dataContext;
            _dataAdapter = dataAdapter;
            _converterFactory = converterFactory;
            _loaderFactory = loaderFactory;
            _columnFactory = columnFactory;
            _columnRepository = columnRepository;
            _rowRepository = rowRepository;
        }

        public void Execute(ImportCsvFileSourceCommand command)
        {
            var source = _repository.GetSource<CsvFileSource>();

            CloseExistingProject();

            Import(source);
        }

        private void CloseExistingProject()
        {
            _eventBus.Raise(new ProjectClosingEvent());

            _stateService.ClearSelectedFilter();

            _stateService.ClearSelectedRows();

            _dataContext.Clear();

            _eventBus.Raise(new ProjectClosedEvent());
        }

        private void Import(CsvFileSource source)
        {
            _eventBus.Raise(new SourceImportingEvent());

            _repository.SetSource(source);

            var dataTable = _dataAdapter.GetTable(source);

            var maps = source.GetMaps();

            var basePath = Path.GetDirectoryName(source.FilePath);

            var columnAggregates = maps
                .Select(p => CreateColumnAggregate(p, basePath))
                .ToList();

            CreateRows(dataTable, columnAggregates);

            CreateColumns(maps);
            
            _eventBus.Raise(new SourceImportedEvent());
        }

        private ColumnAggregate CreateColumnAggregate(SourceMap column, string basePath)
        {
            var converter = _converterFactory.Create(typeof (string), column.DataType);

            var loader = _loaderFactory.Create(column.DataType, basePath);

            var aggregate = new ColumnAggregate(column, converter, loader);

            return aggregate;
        }

        private void CreateColumns(List<SourceMap> sourceMaps)
        {
            // NOTE:  Removed parallel-for loop due to odd async issues
            for (int i = 0; i < sourceMaps.Count; i++)
                CreateColumn(sourceMaps, i);
        }

        private void CreateColumn(List<SourceMap> sourceMap, int i)
        {
            var map = sourceMap[i];

            var values = _rowRepository.GetAll()
                .Select(p => p[i])
                .ToList();

            var column = _columnFactory.Create(
                i + 1,
                i, 
                map.Name, 
                map.DataType,
                map.SemanticType,
                values);

            _columnRepository.Add(column);
        }

        private void CreateRows(
            DataTable dataTable, 
            List<ColumnAggregate> columnAggregates)
        {
            // NOTE:  Removed parallel-for loop due to odd async issues
            for (int i = 0; i < dataTable.Rows.Count; i++)
                CreateRow(dataTable, columnAggregates, i);
        }

        private void CreateRow(
            DataTable dataTable, 
            List<ColumnAggregate> columnAggregates, 
            int i)
        {
            var dataRow = dataTable.Rows[i];

            var row = new Row(i + 1, columnAggregates.Count);

            for (int j = 0; j < columnAggregates.Count; j++)
            {
                var field = columnAggregates[j].Converter.Convert(dataRow[j]);

                if (columnAggregates[j].Loader != null)
                    field = columnAggregates[j].Loader.Load((string) field);

                row[j] = field;
            }  

            _rowRepository.Add(row);

            var progress = (i + 1) / (double) dataTable.Rows.Count;

            _eventBus.Raise(new SourceImportProgressChangedEvent(progress));
        }

        private class ColumnAggregate
        {
            private readonly SourceMap _sourceMap;
            private readonly IDataTypeConverter _converter;
            private readonly IDataLoader _loader;

            public ColumnAggregate(SourceMap sourceMap, IDataTypeConverter converter, IDataLoader loader)
            {
                _sourceMap = sourceMap;
                _converter = converter;
                _loader = loader;
            }

            public SourceMap SourceMap
            {
                get { return _sourceMap; }
            }

            public IDataTypeConverter Converter
            {
                get { return _converter; }
            }

            public IDataLoader Loader
            {
                get { return _loader; }
            }
        }
    }
}
