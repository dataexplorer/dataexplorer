using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Predicates
{
    public class IntegerPredicate
    {
        public Func<Row, bool> Create(Column column, int lowerValue, int upperValue)
        {
            return p => ((int?) p[column.Index]) >= lowerValue
                && ((int?) p[column.Index]) <= upperValue;
        }
    }
}
