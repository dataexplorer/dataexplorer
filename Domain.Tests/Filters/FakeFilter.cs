using System;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Tests.Filters
{
    public class FakeFilter : Filter
    {
        public FakeFilter() : base(null, false)
        {
        }

        public FakeFilter(Column column, bool includeNull)
            : base(column, includeNull)
        {
        }

        public override Func<Row, bool> CreatePredicate()
        {
            throw new NotImplementedException();
        }
    }
}
