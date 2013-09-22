using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Filters
{
    public class BooleanFilter : Filter
    {
        private readonly List<bool?> _values;

        public BooleanFilter(Column column, List<bool?> values)
            : base(column)
        {
            _values = values;
        }

        public BooleanFilter(Column column, bool? value)
            : base(column)
        {
            _values = new List<bool?> { value };
        }

        public List<bool?> Values
        {
            get { return _values; }
        }

        public override Func<Row, bool> CreatePredicate()
        {
            return p => _values.Contains(((bool?) p[_column.Index]));
        }
    }
}
