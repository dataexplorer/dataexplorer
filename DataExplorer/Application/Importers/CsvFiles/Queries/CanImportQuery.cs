using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Sources;

namespace DataExplorer.Application.Importers.CsvFiles.Queries
{
    public class CanImportQuery : ICanImportQuery
    {
        private readonly ISourceRepository _repository;

        public CanImportQuery(ISourceRepository repository)
        {
            _repository = repository;
        }

        public bool Query()
        {
            var source = _repository.GetSource<CsvFileSource>();

            return !String.IsNullOrEmpty(source.FilePath);
        }
    }
}
