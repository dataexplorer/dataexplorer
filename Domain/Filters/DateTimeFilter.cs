using System;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Predicates;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Filters
{
    public class DateTimeFilter : Filter
    {
        protected DateTime _lowerValue;
        protected DateTime _upperValue;
        
        public DateTimeFilter(Column column, DateTime lowerValue, DateTime upperValue, bool includeNull) 
            : base(column, includeNull)
        {
            _lowerValue = lowerValue;
            _upperValue = upperValue;
        }

        public DateTime LowerValue
        {
            get { return _lowerValue; }
            set { _lowerValue = value; }
        }

        public DateTime UpperValue
        {
            get { return _upperValue; }
            set { _upperValue = value; }
        }

        public override Func<Row, bool> CreatePredicate()
        {
            return _column.HasNulls 
                ? new NullableDateTimePredicate().Create(_column, _lowerValue, _upperValue, _includeNull)
                : new DateTimePredicate().Create(_column, _lowerValue, _upperValue);
        }
    }
}
