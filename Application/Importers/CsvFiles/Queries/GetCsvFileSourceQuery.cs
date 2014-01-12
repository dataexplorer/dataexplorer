using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Sources;

namespace DataExplorer.Application.Importers.CsvFiles.Queries
{
    public interface IGetCsvFileSourceQuery
    {
        CsvFileSourceDto Query();
    }

    public class GetCsvFileSourceQuery : IGetCsvFileSourceQuery
    {
        private readonly ISourceRepository _repository;
        private readonly ICsvFileSourceAdapter _adapter;

        public GetCsvFileSourceQuery(
            ISourceRepository repository,
            ICsvFileSourceAdapter adapter)
        {
            _repository = repository;
            _adapter = adapter;
        }

        public CsvFileSourceDto Query()
        {
            var source = _repository.GetSource<CsvFileSource>();

            var sourceDto = _adapter.Adapt(source);

            return sourceDto;
        }
    }
}
