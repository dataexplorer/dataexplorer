using System;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Predicates;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Filters
{
    public class FloatFilter : Filter
    {
        protected double _lowerValue;
        protected double _upperValue;
        
        public FloatFilter(Column column, double lowerValue, double upperValue, bool includeNull)
            : base(column, includeNull)
        {
            _lowerValue = lowerValue;
            _upperValue = upperValue;
        }

        public double LowerValue
        {
            get { return _lowerValue; }
            set { _lowerValue = value; }
        }

        public double UpperValue
        {
            get { return _upperValue; }
            set { _upperValue = value; }
        }

        public override Func<Row, bool> CreatePredicate()
        {
            return _column.HasNulls
                ? new NullableFloatPredicate()
                    .Create(_column, _lowerValue, _upperValue, _includeNull)
                : new FloatPredicate()
                    .Create(_column, _lowerValue, _upperValue);
        }
    }
}
