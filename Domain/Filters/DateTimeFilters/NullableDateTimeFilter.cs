using System;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Predicates;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Filters.DateTimeFilters
{
    public class NullableDateTimeFilter : DateTimeFilter
    {
        private readonly bool _includeNulls;

        public NullableDateTimeFilter(Column column, DateTime lowerValue, DateTime upperValue, bool includeNulls)
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
            return new NullableDateTimePredicate()
                .Create(_column, _lowerValue, _upperValue, IncludeNulls);
        }
    }
}
