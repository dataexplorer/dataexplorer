using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Predicates
{
    public class NullableBooleanPredicate
    {
        public Func<Row, bool> Create(Column column, bool isTrue, bool isFalse, bool isNull)
        {
            return p => (isNull && p[column.Index] == null)
                || (isTrue && p[column.Index] != null && ((bool?) p[column.Index]).Value)
                || (isFalse && p[column.Index] != null && !((bool?) p[column.Index]).Value);
        }
    }
}
