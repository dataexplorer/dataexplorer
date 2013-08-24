using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Sources;

namespace DataExplorer.Application.Importers.CsvFile
{
    public class CsvFileImportService : ICsvFileImportService, IHandler<CsvFilePathChangedEvent>
    {
        private readonly ISourceFactory _factory;
        private readonly ISourceRepository _repository;

        public event FilePathChangedEvent FilePathChanged;

        public CsvFileImportService(
            ISourceFactory factory,
            ISourceRepository repository)
        {
            _factory = factory;
            _repository = repository;
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

        public void Handle(CsvFilePathChangedEvent args)
        {
            if (FilePathChanged != null)
                FilePathChanged(this, EventArgs.Empty);
        }
    }
}
