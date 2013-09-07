using System;
using System.Collections.Generic;
using System.Data;
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
using DataExplorer.Persistence;
using DataExplorer.Persistence.Columns;

namespace DataExplorer.Application.Importers.CsvFile
{
    public class CsvFileImportService :
        ICsvFileImportService, 
        IDomainHandler<CsvFilePathChangedEvent>
    {
        private readonly ISourceRepository _repository;
        private readonly ICsvFileAdapter _adapter;
        private readonly IDataTypeConverterFactory _converterFactory;
        private readonly IRowRepository _rowRepository;
        private readonly IColumnRepository _columnRepository;
        private readonly IDataContext _dataContext;

        public CsvFileImportService(
            ISourceRepository repository,
            ICsvFileAdapter adapter,
            IDataTypeConverterFactory converterFactory,
            IRowRepository rowRepository,
            IColumnRepository columnRepository,
            IDataContext dataContext)
        {
            _repository = repository;
            _adapter = adapter;
            _converterFactory = converterFactory;
            _rowRepository = rowRepository;
            _columnRepository = columnRepository;
            _dataContext = dataContext;
        }

        public string GetFilePath()
        {
            var importer = _repository.GetSource<CsvFileSource>();
            
            return importer.FilePath;
        }

        public void SetFilePath(string filePath)
        {
            var importer = _repository.GetSource<CsvFileSource>();

            importer.FilePath = filePath;
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

            var dataColumns = _adapter.GetDataColumns(source);

            var dataTable = _adapter.GetDataTable(source);

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

        public bool IsImporting()
        {
            throw new NotImplementedException();
        }

        public void Handle(CsvFilePathChangedEvent args)
        {
            AppEvents.Raise(new CsvFilePathChangedAppEvent());
        }
    }
}
