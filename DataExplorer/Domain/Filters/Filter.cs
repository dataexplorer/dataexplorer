using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Filters
{
    public abstract class Filter
    {
        protected readonly Column _column;

        protected Filter(Column column)
        {
            _column = column;
        }

        public Column Column
        {
            get { return _column; }
        }

        public abstract Func<Row, bool> CreatePredicate();
    }
}
