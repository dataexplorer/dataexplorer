using System;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Predicates;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Filters.IntegerFilters
{
    public class NullableIntegerFilter : IntegerFilter
    {
        private readonly bool _includeNulls;

        public NullableIntegerFilter(Column column, int lowerValue, int upperValue, bool includeNulls)
            : base(column, lowerValue, upperValue)
        {
            _includeNulls = includeNulls;
        }
        
        public bool IncludeNulls
        {
            get { return _includeNulls; }
        }

        public override Func<Row, bool> CreatePredicate()
        {
            return new NullableIntegerPredicate()
                .Create(_column, _lowerValue, _upperValue, _includeNulls);
        }
    }
}
