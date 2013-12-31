using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Rows
{
    public class Row
    {
        private readonly int _id;
        private readonly object[] _fields;

        public Row(int id)
        {
            _id = id;
        }

        public Row(int id, int fields)
        {
            _id = id;
            _fields = new object[fields];
        }

        public Row(int id, IEnumerable<object> fields)
        {
            _id = id;
            _fields = fields.ToArray();
        }

        public int Id
        {
            get { return _id; }
        }

        public IEnumerable<object> Fields
        {
            get { return _fields; }
        }
        
        public object this[int columnIndex]
        {
            get { return _fields[columnIndex]; }
            set { _fields[columnIndex] = value; }
        }
    }
}
