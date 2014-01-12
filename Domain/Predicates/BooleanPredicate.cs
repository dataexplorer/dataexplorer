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
        public Func<Row, bool> Create(Column column, List<bool?> values)
        {
            return p => values.Contains(((bool?) p[column.Index]));
        }
    }
}
