using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Application.Columns.Queries
{
    public class GetDistinctColumnValuesQueryHandler : IQueryHandler<GetDistinctColumnValuesQuery, List<object>>
    {
        private readonly IColumnRepository _repository;

        public GetDistinctColumnValuesQueryHandler(IColumnRepository repository)
        {
            _repository = repository;
        }

        public List<object> Execute(GetDistinctColumnValuesQuery query)
        {
            var column = _repository.Get(query.Id);

            var values = column.Values.Distinct().ToList();

            return values;
        }
    }
}
