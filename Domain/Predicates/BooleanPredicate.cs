using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Predicates
{
    public class BooleanPredicate
    {
        public Func<Row, bool> Create(Column column, bool isTrue, bool isFalse)
        {
            return p => isTrue && ((bool) p[column.Index])
                || isFalse && !((bool) p[column.Index]);
        }
    }
}
