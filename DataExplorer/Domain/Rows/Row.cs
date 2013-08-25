using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Rows
{
    public class Row
    {
        private readonly object[] _fields;

        public Row()
        { }

        public Row(int fields)
        {
            _fields = new object[fields];
        }

        public Row(List<object> fields)
        {
            _fields = fields.ToArray();
        }

        public object this[int columnIndex]
        {
            get { return _fields[columnIndex]; }
            set { _fields[columnIndex] = value; }
        }
    }
}
