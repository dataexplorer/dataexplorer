using System;
using System.Collections.Generic;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Predicates;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Filters.BooleanFilters
{
    public class BooleanFilter : Filter
    {
        private bool _includeTrue;
        private bool _includeFalse;
        private bool _includeNull;

        public BooleanFilter(Column column, bool includeTrue, bool includeFalse, bool includeNull)
            : base(column)
        {
            _includeTrue = includeTrue;
            _includeFalse = includeFalse;
            _includeNull = includeNull;
        }

        public bool IncludeTrue
        {
            get { return _includeTrue; }
        }

        public bool IncludeFalse
        {
            get { return _includeFalse; }
        }

        public bool IncludeNull
        {
            get { return _includeNull; }
        }

        public override Func<Row, bool> CreatePredicate()
        {
            return _column.HasNulls 
                ? new NullableBooleanPredicate().Create(_column, _includeTrue, _includeFalse, _includeNull) 
                : new BooleanPredicate().Create(_column, _includeTrue, _includeFalse);
        }
    }
}
