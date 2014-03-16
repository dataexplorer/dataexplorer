using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Domain.DataTypes.Detectors;
using DataExplorer.Domain.Semantics;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Sources.Maps;

namespace DataExplorer.Application.Importers.CsvFiles.Commands
{
    public class UpdateCsvFileSourceCommandHandler 
        : ICommandHandler<UpdateCsvFileSourceCommand>
    {
        private readonly ISourceRepository _repository;
        private readonly ICsvFileDataAdapter _dataAdapter;
        private readonly IDataTypeDetector _dataTypeDetector;
        private readonly ISemanticTypeDetector _semanticTypeDetector;
        private readonly ISourceMapFactory _factory;
        private readonly IEventBus _eventBus;

        public UpdateCsvFileSourceCommandHandler(
            ISourceRepository repository, 
            ICsvFileDataAdapter dataAdapter,
            IDataTypeDetector dataTypeDetector,
            ISemanticTypeDetector semanticTypeDetector,
            ISourceMapFactory factory, 
            IEventBus eventBus)
        {
            _repository = repository;
            _dataAdapter = dataAdapter;
            _dataTypeDetector = dataTypeDetector;
            _semanticTypeDetector = semanticTypeDetector;
            _factory = factory;
            _eventBus = eventBus;
        }

        public void Execute(UpdateCsvFileSourceCommand command)
        {
            var source = _repository.GetSource<CsvFileSource>();

            source.FilePath = command.FilePath;

            var table = _dataAdapter.GetTable(source);

            var maps = table.Columns.Cast<DataColumn>()
                .Select(column => CreateMap(table, column))
                .ToList();

            source.SetMaps(maps);

            _eventBus.Raise(new CsvFileSourceChangedEvent());
        }

        private SourceMap CreateMap(DataTable dataTable, DataColumn column)
        {
            var values = dataTable.Rows.Cast<DataRow>()
                .Select(p => p[column.Ordinal]).ToList();

            var dataType = _dataTypeDetector.Detect(values);

            var semanticType = _semanticTypeDetector.Detect(dataType, values);

            var map = _factory.Create(
                column.Ordinal, 
                column.ColumnName, 
                dataType, 
                semanticType);
            
            return map;
        }
    }
}
