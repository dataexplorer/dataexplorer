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
        
        public BooleanFilter(Column column, bool includeTrue, bool includeFalse, bool includeNull)
            : base(column, includeNull)
        {
            _includeTrue = includeTrue;
            _includeFalse = includeFalse;
        }

        public bool IncludeTrue
        {
            get { return _includeTrue; }
            set { _includeTrue = value; }
        }

        public bool IncludeFalse
        {
            get { return _includeFalse; }
            set { _includeFalse = value; }
        }
        
        public override Func<Row, bool> CreatePredicate()
        {
            return _column.HasNulls 
                ? new NullableBooleanPredicate()
                    .Create(_column, _includeTrue, _includeFalse, _includeNull) 
                : new BooleanPredicate()
                    .Create(_column, _includeTrue, _includeFalse);
        }
    }
}
