using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Sources.Maps;
using DataExplorer.Infrastructure.Importers.CsvFile;

namespace DataExplorer.Application.Importers.CsvFiles.Commands
{
    public class UpdateCsvFileSourceCommand : IUpdateCsvFileSourceCommand
    {
        private readonly ISourceRepository _repository;
        private readonly ICsvFileDataAdapter _dataAdapter;
        private readonly ISourceMapFactory _factory;

        public UpdateCsvFileSourceCommand(
            ISourceRepository repository, 
            ICsvFileDataAdapter dataAdapter, 
            ISourceMapFactory factory)
        {
            _repository = repository;
            _dataAdapter = dataAdapter;
            _factory = factory;
        }

        public void Execute(string filePath)
        {
            var source = _repository.GetSource<CsvFileSource>();

            source.FilePath = filePath;

            var columns = _dataAdapter.GetDataColumns(source);

            var maps = columns
                .Select(p => _factory.Create(p))
                .ToList();

            source.SetMaps(maps);

            AppEvents.Raise(new CsvFileSourceChangedEvent());
        }
    }
}
