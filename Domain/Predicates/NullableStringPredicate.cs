using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Predicates
{
    public class NullableStringPredicate
    {
        public Func<Row, bool> Create(Column column, string value, bool includeNulls)
        {
            var stringPredicate = new StringPredicate()
                .Create(column, value);

            return p => (((string) p[column.Index]) == null
                    && includeNulls)
                || stringPredicate(p);
        }
    }
}
