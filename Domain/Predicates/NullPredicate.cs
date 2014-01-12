using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Predicates
{
    public class NullPredicate
    {
        public Func<Row, bool> Create(Column column)
        {
            return p => p[column.Index] == null;
        }
    }
}
