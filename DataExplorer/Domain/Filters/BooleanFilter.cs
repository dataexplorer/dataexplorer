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
        private readonly Column _column;
        private readonly List<bool?> _values;

        public BooleanFilter(Column column)
        {
            _column = column;
            _values = new List<bool?>();
            _values.Add(null);
            _values.Add(true);
            _values.Add(false);
        }

        public BooleanFilter(Column column, bool value)
        {
            _column = column;
            _values = new List<bool?> { value };
        }

        public List<bool?> Values
        {
            get { return _values; }
        }

        public override Func<Row, bool> CreatePredicate()
        {
            return p => _values.Contains(((bool) p[_column.Index]));
        }
    }
}
