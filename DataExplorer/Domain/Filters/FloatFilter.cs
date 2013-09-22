using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Filters
{
    public class FloatFilter : Filter
    {
        private readonly double _lowerValue;
        private readonly double _upperValue;

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
            return p => ((double?) p[_column.Index]) >= _lowerValue
                && ((double?) p[_column.Index]) <= _upperValue;
        }
    }
}
