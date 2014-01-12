using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Predicates
{
    public class NullableIntegerPredicate
    {
        public Func<Row, bool> Create(Column column, int lowerValue, int upperValue, bool includeNulls)
        {
            var integerPredicate = new IntegerPredicate()
                .Create(column, lowerValue, upperValue);

            return p => (((int?) p[column.Index]) == null
                    && includeNulls)
                || integerPredicate(p);
        }
    }
}
