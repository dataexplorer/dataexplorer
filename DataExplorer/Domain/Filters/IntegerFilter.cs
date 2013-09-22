using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Filters
{
    public class IntegerFilter : Filter
    {
         private readonly int _lowerValue;
        private readonly int _upperValue;

        public IntegerFilter(Column column, int lowerValue, int upperValue)
            : base(column)
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
            return p => ((int?) p[_column.Index]) >= _lowerValue
                && ((int?) p[_column.Index]) <= _upperValue;
        }
    }
}
