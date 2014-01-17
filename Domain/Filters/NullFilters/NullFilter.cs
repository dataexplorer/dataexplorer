using System;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Filters.NullFilters
{
    public class NullFilter : Filter
    {
        public NullFilter(Column column) : base(column, true)
        {
        }

        public override Func<Row, bool> CreatePredicate()
        {
            return p => p[_column.Index] == null;
        }
    }
}
