using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Application.Filters.Queries
{
    public class GetFiltersQueryHandler : IQueryHandler<GetFiltersQuery, List<Filter>>
    {
        private readonly IFilterRepository _repository;

        public GetFiltersQueryHandler(IFilterRepository repository)
        {
            _repository = repository;
        }

        public List<Filter> Execute(GetFiltersQuery query)
        {
            return _repository.GetAll();
        }
    }
}
