using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Application.Columns.Queries
{
    public class GetDistinctColumnValuesQuery : IGetDistinctColumnValuesQuery
    {
        private readonly IColumnRepository _repository;

        public GetDistinctColumnValuesQuery(IColumnRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<object> Execute(int id)
        {
            var column = _repository.Get(id);

            var values = column.Values.Distinct();

            return values;
        }
    }
}
