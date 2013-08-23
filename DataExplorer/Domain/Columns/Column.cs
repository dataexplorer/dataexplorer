using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Columns
{
    public class Column
    {
        private readonly int _id;
        private readonly int _index;
        private readonly string _name;
        private readonly Type _type;
        private readonly List<object> _values;
        private readonly object _min;
        private readonly object _max;

        public Column(int id, int index, string name, Type type, List<object> values)
        {
            _id = id;
            _index = index;
            _name = name;
            _type = type;
            _values = values;
            _min = values.Min();
            _max = values.Max();
            
        }

        public int Id
        {
            get { return _id; }
        }

        public int Index
        {
            get { return _index; }
        }

        public string Name
        {
            get { return _name; }
        }

        public Type Type
        {
            get { return _type; }
        }

        public object Min
        {
            get { return _min; }
        }

        public object Max
        {
            get { return _max; }
        }

        public List<object> Values
        {
            get { return _values; }
        }
    }
}
