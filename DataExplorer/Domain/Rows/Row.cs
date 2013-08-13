using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Rows
{
    public class Row
    {
        private readonly List<object> _fields;

        public Row() : this(new List<object>())
        { }

        public Row(List<object> fields)
        {
            _fields = fields;
        }

        public object this[int columnIndex]
        {
            get { return _fields[columnIndex]; }
        }
    }
}
