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
    public class DateTimeFilter : Filter
    {
        private readonly DateTime _lowerValue;
        private readonly DateTime _upperValue;

        public DateTimeFilter(Column column, DateTime lowerValue, DateTime upperValue) 
            : base(column)
        {
            _lowerValue = lowerValue;
            _upperValue = upperValue;
        }

        public DateTime LowerValue
        {
            get { return _lowerValue; }
        }

        public DateTime UpperValue
        {
            get { return _upperValue; }
        }

        public override Func<Row, bool> CreatePredicate()
        {
            return new DateTimePredicate()
                .Create(_column, _lowerValue, _upperValue);
        }
    }
}
