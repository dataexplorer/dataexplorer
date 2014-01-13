using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Queries;

namespace DataExplorer.Application.Columns.Queries
{
    public class GetDistinctColumnValuesQuery : EntityIdQuery<List<object>>
    {
        public GetDistinctColumnValuesQuery(int id) : base(id)
        {
        }
    }
}
