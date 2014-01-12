using System;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Tests.Domain.Filters
{
    public class FakeFilter : Filter
    {
        public FakeFilter() : base(null)
        {
        }

        public FakeFilter(Column column)
            : base(column)
        {
        }

        public override Func<Row, bool> CreatePredicate()
        {
            throw new NotImplementedException();
        }
    }
}
