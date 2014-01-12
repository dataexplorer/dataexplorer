using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Predicates
{
    public class FloatPredicate
    {
        public Func<Row, bool> Create(Column column, double lowerValue, double upperValue)
        {
            return p => ((double?) p[column.Index]) >= lowerValue
                && ((double?) p[column.Index]) <= upperValue;
        }
    }
}
