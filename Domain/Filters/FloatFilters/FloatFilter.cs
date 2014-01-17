using System;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Predicates;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Filters.FloatFilters
{
    public class FloatFilter : Filter
    {
        protected readonly double _lowerValue;
        protected readonly double _upperValue;
        private readonly bool _includeNull;
        
        public FloatFilter(Column column, double lowerValue, double upperValue, bool includeNull)
            : base(column)
        {
            _lowerValue = lowerValue;
            _upperValue = upperValue;
            _includeNull = includeNull;
        }

        public double LowerValue
        {
            get { return _lowerValue; }
        }

        public double UpperValue
        {
            get { return _upperValue; }
        }

        public bool IncludeNull
        {
            get { return _includeNull; }
        }

        public override Func<Row, bool> CreatePredicate()
        {
            return _column.HasNulls 
                ? new FloatPredicate().Create(_column, _lowerValue, _upperValue)
                : new NullableFloatPredicate().Create(_column, _lowerValue, _upperValue, _includeNull);
        }
    }
}
