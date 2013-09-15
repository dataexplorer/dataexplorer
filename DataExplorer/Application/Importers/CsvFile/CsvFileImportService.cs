using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Events;
using DataExplorer.Application.Importers.CsvFile.Events;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Converters;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Sources.Maps;
using DataExplorer.Persistence;

namespace DataExplorer.Application.Importers.CsvFile
{
    public class CsvFileImportService : ICsvFileImportService
    {
        private readonly ISourceRepository _repository;
        private readonly ICsvFileDataAdapter _dataAdapter;
        private readonly IDataTypeConverterFactory _converterFactory;
        private readonly IRowRepository _rowRepository;
        private readonly IColumnRepository _columnRepository;
        private readonly IDataContext _dataContext;
        private readonly ISourceMapFactory _sourceMapFactory;
        private readonly ICsvFileSourceAdapter _adapter;

        public CsvFileImportService(
            ISourceRepository repository,
            ICsvFileDataAdapter dataAdapter,
            IDataTypeConverterFactory converterFactory,
            IRowRepository rowRepository,
            IColumnRepository columnRepository,
            IDataContext dataContext,
            ISourceMapFactory sourceMapFactory,
            ICsvFileSourceAdapter adapter)
        {
            _repository = repository;
            _dataAdapter = dataAdapter;
            _converterFactory = converterFactory;
            _rowRepository = rowRepository;
            _columnRepository = columnRepository;
            _dataContext = dataContext;
            _sourceMapFactory = sourceMapFactory;
            _adapter = adapter;
        }

        public CsvFileSourceDto GetSource()
        {
            var source = _repository.GetSource<CsvFileSource>();

            var sourceDto = _adapter.Adapt(source);

            return sourceDto;
        }

        public void UpdateSource(string filePath)
        {
            var source = _repository.GetSource<CsvFileSource>();

            source.FilePath = filePath;

            var columns = _dataAdapter.GetDataColumns(source);

            var maps = columns
                .Select(p => _sourceMapFactory.Create(p))
                .ToList();

            source.SetMaps(maps);

            AppEvents.Raise(new CsvFileSourceChangedEvent());
        }
        
        public List<SourceMap> GetMaps()
        {
            var source = _repository.GetSource<CsvFileSource>();

            var maps = source.GetMaps();

            return maps.ToList();
        }

        public bool CanImport()
        {
            var source = _repository.GetSource<CsvFileSource>();

            return !String.IsNullOrEmpty(source.FilePath);
        }

        public void Import()
        {
            AppEvents.Raise(new CsvFileImportingEvent());

            var source = _repository.GetSource<CsvFileSource>();

            _dataContext.Clear();

            _repository.SetSource(source);

            var dataColumns = _dataAdapter.GetDataColumns(source);

            var dataTable = _dataAdapter.GetDataTable(source);

            var converters = dataColumns
                .Select(p => _converterFactory.Create(typeof(string), p.DataType))
                .ToList();

            // TODO: Move into separate component
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var dataRow = dataTable.Rows[i];

                var row = new Row(dataColumns.Count);

                for (int j = 0; j < dataColumns.Count; j++)
                    row[j] = converters[j].Convert(dataRow[j]);
                
                _rowRepository.Add(row);

                var progress = (i + 1) / (double) dataTable.Rows.Count;

                AppEvents.Raise(new CsvFileImportProgressChangedEvent(progress));
            }

            // TODO: Move into separate component
            for (int i = 0; i < dataColumns.Count; i++)
            {
                var dataColumn = dataColumns[i];

                var values = _rowRepository.GetAll()
                    .Select(p => p[i])
                    .OrderBy(p => p)
                    .ToList();

                var column = new Column(i + 1, i, dataColumn.ColumnName, dataColumn.DataType, values);

                _columnRepository.Add(column);
            }
            
            AppEvents.Raise(new CsvFileImportedEvent());
        }
    }
}
