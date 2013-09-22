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
    public class NullableFloatFilter : FloatFilter
    {
        private readonly bool _includeNulls;

        public NullableFloatFilter(Column column, double lowerValue, double upperValue, bool includeNulls)
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
            return new NullableFloatPredicate()
                .Create(_column, _lowerValue, _upperValue, IncludeNulls);
        }
    }
}
