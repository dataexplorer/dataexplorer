using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Predicates;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Filters
{
    public class FloatFilter : Filter
    {
        protected readonly double _lowerValue;
        protected readonly double _upperValue;

        public FloatFilter(Column column, double lowerValue, double upperValue)
            : base(column)
        {
            _lowerValue = lowerValue;
            _upperValue = upperValue;
        }

        public double LowerValue
        {
            get { return _lowerValue; }
        }

        public double UpperValue
        {
            get { return _upperValue; }
        }

        public override Func<Row, bool> CreatePredicate()
        {
            return new FloatPredicate()
                .Create(_column, _lowerValue, _upperValue);
        }
    }
}
