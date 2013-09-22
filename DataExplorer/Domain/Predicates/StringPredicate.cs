using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Predicates
{
    public class StringPredicate
    {
        public Func<Row, bool> Create(Column column, string value)
        {
            return p => ((string)p[column.Index]) != null 
                && ((string)p[column.Index]).StartsWith(value, true, CultureInfo.InvariantCulture);
        }
    }
}
