using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Filters
{
    public abstract class Filter
    {
        public abstract Func<Row, bool> CreatePredicate();
    }
}
