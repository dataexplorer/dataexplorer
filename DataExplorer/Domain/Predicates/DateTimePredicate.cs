using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Predicates
{
    public class DateTimePredicate
    {
        public Func<Row, bool> Create(Column column, DateTime lowerValue, DateTime upperValue)
        {
            return p => ((DateTime?)p[column.Index]) >= lowerValue
                && ((DateTime?)p[column.Index]) <= upperValue;
        }
    }
}
