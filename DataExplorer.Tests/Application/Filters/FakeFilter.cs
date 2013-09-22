using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Tests.Application.Filters
{
    public class FakeFilter : Filter
    {
        public FakeFilter() : base(null)
        {
        }

        public override Func<Row, bool> CreatePredicate()
        {
            throw new NotImplementedException();
        }
    }
}
