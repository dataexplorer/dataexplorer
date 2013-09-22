using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Filters
{
    public class StringFilter : Filter
    {
        private readonly string _value;
        
        public StringFilter(Column column, string value)
            : base(column)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

        public override Func<Row, bool> CreatePredicate()
        {
            return p => ((string) p[_column.Index]).StartsWith(_value);
        }
    }
}
