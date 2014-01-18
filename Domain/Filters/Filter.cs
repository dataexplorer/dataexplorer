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
        protected bool _includeNull;

        protected Filter(Column column, bool includeNull)
        {
            _column = column;
            _includeNull = includeNull;
        }

        public Column Column
        {
            get { return _column; }
        }

        public bool IncludeNull
        {
            get { return _includeNull; }
            set { _includeNull = value; }
        }

        public abstract Func<Row, bool> CreatePredicate();
    }
}
