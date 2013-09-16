using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Tests.Domain.Columns
{
    public class ColumnBuilder
    {
        private int _id;
        private int _index;
        private string _name;
        private Type _type;
        private bool _hasNulls;
        private List<object> _values; 

        public ColumnBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public ColumnBuilder WithIndex(int index)
        {
            _index = index;
            return this;
        }

        public ColumnBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ColumnBuilder WithType(Type type)
        {
            _type = type;
            return this;
        }

        public ColumnBuilder WithNulls()
        {
            _hasNulls = true;
            return this;
        }

        public ColumnBuilder WithValue(object value)
        {
            if (_values == null)
                _values = new List<object>();

            _values.Add(value);

            return this;
        }

        public ColumnBuilder WithValues(IEnumerable<object> values)
        {
            if (_values == null)
                _values = new List<object>();

            _values.AddRange(values);

            return this;
        }

        public Column Build()
        {
            var values = new List<object>();

            if (_hasNulls)
                values.Add(null);

            if (_values != null)
                values.AddRange(_values);

            return new Column(_id, _index, _name, _type, values);
        }
    }
}
