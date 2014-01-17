using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Predicates
{
    public class NullableDateTimePredicate
    {
        public Func<Row, bool> Create(Column column, DateTime lowerValue, DateTime upperValue, bool includeNull)
        {
            var dateTimePredicate = new DateTimePredicate()
                .Create(column, lowerValue, upperValue);

            return p => (((DateTime?) p[column.Index]) == null 
                    && includeNull)
                || dateTimePredicate(p);
        }
    }
}
