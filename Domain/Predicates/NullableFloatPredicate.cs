using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Predicates
{
    public class NullableFloatPredicate
    {
        public Func<Row, bool> Create(Column column, double lowerValue, double upperValue, bool includeNulls)
        {
            var floatPredicate = new FloatPredicate()
                .Create(column, lowerValue, upperValue);

            return p => (((double?) p[column.Index]) == null
                    && includeNulls)
                || floatPredicate(p);
        }
    }
}
