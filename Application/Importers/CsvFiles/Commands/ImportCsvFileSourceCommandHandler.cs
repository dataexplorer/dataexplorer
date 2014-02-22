using System;
using System.Collections.Generic;
using System.Data;
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
using DataExplorer.Domain.Converters;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Sources;

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
        private readonly IRowRepository _rowRepository;
        private readonly IColumnRepository _columnRepository;

        public ImportCsvFileSourceCommandHandler(
            ISourceRepository repository, 
            IEventBus eventBus, 
            IApplicationStateService stateService,
            IDataContext dataContext, 
            ICsvFileDataAdapter dataAdapter, 
            IDataTypeConverterFactory converterFactory, 
            IRowRepository rowRepository, 
            IColumnRepository columnRepository)
        {
            _repository = repository;
            _eventBus = eventBus;
            _stateService = stateService;
            _dataContext = dataContext;
            _dataAdapter = dataAdapter;
            _converterFactory = converterFactory;
            _rowRepository = rowRepository;
            _columnRepository = columnRepository;
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

            var dataColumns = _dataAdapter.GetDataColumns(source);

            var dataTable = _dataAdapter.GetDataTable(source);

            var converters = dataColumns
                .Select(p => _converterFactory.Create(typeof (string), p.DataType))
                .ToList();

            CreateRowsAsync(dataTable, dataColumns, converters);

            CreateColumns(dataColumns);

            _eventBus.Raise(new SourceImportedEvent());
        }

        private void CreateRowsAsync(DataTable dataTable, List<DataColumn> dataColumns, List<IDataTypeConverter> converters)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
                CreateRow(dataTable, dataColumns, converters, i);

            // NOTE:  Removed due to odd async issue
            //Parallel.For(0, dataTable.Rows.Count, 
            //    i => CreateRow(dataTable, dataColumns, converters, i));
        }

        private void CreateRow(DataTable dataTable, List<DataColumn> dataColumns, List<IDataTypeConverter> converters, int i)
        {
            var dataRow = dataTable.Rows[i];

            var row = new Row(i + 1, dataColumns.Count);

            for (int j = 0; j < dataColumns.Count; j++)
                row[j] = converters[j].Convert(dataRow[j]);

            _rowRepository.Add(row);

            var progress = (i + 1)/(double) dataTable.Rows.Count;

            _eventBus.Raise(new SourceImportProgressChangedEvent(progress));
        }

        private void CreateColumns(List<DataColumn> dataColumns)
        {
            for (int i = 0; i< dataColumns.Count; i++)
                CreateColumn(dataColumns, i);

            // NOTE: Removed due to odd async issue
            //Parallel.For(0, dataColumns.Count, 
            //    i => CreateColumn(dataColumns, i));
        }

        private void CreateColumn(List<DataColumn> dataColumns, int i)
        {
            var dataColumn = dataColumns[i];

            var values = _rowRepository.GetAll()
                .Select(p => p[i])
                .OrderBy(p => p)
                .ToList();

            var column = new Column(i + 1, i, dataColumn.ColumnName, dataColumn.DataType, values);

            _columnRepository.Add(column);
        }
    }
}
