using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers.CsvFiles.Events;
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
        private readonly ICsvFileDataAdapter _dataAdapter;
        private readonly IDataTypeConverterFactory _converterFactory;
        private readonly IRowRepository _rowRepository;
        private readonly IColumnRepository _columnRepository;
        private readonly IDataContext _dataContext;
        private readonly IEventBus _eventBus;

        public ImportCsvFileSourceCommandHandler(
            ISourceRepository repository, 
            ICsvFileDataAdapter dataAdapter, 
            IDataTypeConverterFactory converterFactory, 
            IRowRepository rowRepository, 
            IColumnRepository columnRepository, 
            IDataContext dataContext, 
            IEventBus eventBus)
        {
            _repository = repository;
            _dataAdapter = dataAdapter;
            _converterFactory = converterFactory;
            _rowRepository = rowRepository;
            _columnRepository = columnRepository;
            _dataContext = dataContext;
            _eventBus = eventBus;
        }

        public void Execute(ImportCsvFileSourceCommand command)
        {
            _eventBus.Raise(new CsvFileImportingEvent());

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

                var row = new Row(i + 1, dataColumns.Count);

                for (int j = 0; j < dataColumns.Count; j++)
                    row[j] = converters[j].Convert(dataRow[j]);

                _rowRepository.Add(row);

                var progress = (i + 1) / (double)dataTable.Rows.Count;

                _eventBus.Raise(new CsvFileImportProgressChangedEvent(progress));
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

            _eventBus.Raise(new CsvFileImportedEvent());
        }
    }
}
