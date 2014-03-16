using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Predicates
{
    public class ImagePredicate
    {
        public Func<Row, bool> Create(Column column, bool isNull, bool isNotNull)
        {
            return p => (isNull && p[column.Index] == null)
                || (isNotNull && p[column.Index] != null);
        }
    }
}
