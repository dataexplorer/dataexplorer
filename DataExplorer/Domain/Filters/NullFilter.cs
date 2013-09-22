using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Filters
{
    public class NullFilter : Filter
    {
        public NullFilter(Column column) : base(column)
        {
        }

        public override Func<Row, bool> CreatePredicate()
        {
            return p => p[_column.Index] == null;
        }
    }
}
