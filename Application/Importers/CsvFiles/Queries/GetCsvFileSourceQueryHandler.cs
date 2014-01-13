using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Domain.Sources;

namespace DataExplorer.Application.Importers.CsvFiles.Queries
{
    public interface IGetCsvFileSourceQuery
    {
        CsvFileSourceDto Query();
    }

    public class GetCsvFileSourceQueryHandler 
        : IQueryHandler<GetCsvFileSourceQuery, CsvFileSourceDto>
    {
        private readonly ISourceRepository _repository;
        private readonly ICsvFileSourceAdapter _adapter;

        public GetCsvFileSourceQueryHandler(
            ISourceRepository repository,
            ICsvFileSourceAdapter adapter)
        {
            _repository = repository;
            _adapter = adapter;
        }

        public CsvFileSourceDto Execute(GetCsvFileSourceQuery query)
        {
            var source = _repository.GetSource<CsvFileSource>();

            var sourceDto = _adapter.Adapt(source);

            return sourceDto;
        }
    }
}
