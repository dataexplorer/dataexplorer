using System;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Predicates;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Filters.IntegerFilters
{
    public class IntegerFilter : Filter
    {
        protected readonly int _lowerValue;
        protected readonly int _upperValue;

        public IntegerFilter(Column column, int lowerValue, int upperValue, bool includeNull)
            : base(column, includeNull)
        {
            _lowerValue = lowerValue;
            _upperValue = upperValue;
        }

        public int LowerValue
        {
            get { return _lowerValue; }
        }

        public int UpperValue
        {
            get { return _upperValue; }
        }

        public override Func<Row, bool> CreatePredicate()
        {
            return new IntegerPredicate()
                .Create(_column, _lowerValue, _upperValue);
        }
    }
}
