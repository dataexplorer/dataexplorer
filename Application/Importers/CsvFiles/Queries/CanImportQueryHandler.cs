using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Domain.Sources;

namespace DataExplorer.Application.Importers.CsvFiles.Queries
{
    public class CanImportQueryHandler 
        : IQueryHandler<CanImportQuery, bool>
    {
        private readonly ISourceRepository _repository;

        public CanImportQueryHandler(ISourceRepository repository)
        {
            _repository = repository;
        }

        public bool Execute(CanImportQuery query)
        {
            var source = _repository.GetSource<CsvFileSource>();

            return !String.IsNullOrEmpty(source.FilePath);
        }
    }
}
