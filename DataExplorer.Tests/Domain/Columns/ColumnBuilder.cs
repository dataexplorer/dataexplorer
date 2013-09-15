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
        private object _min;
        private object _max;
        private bool _hasNulls;

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

        public ColumnBuilder WithMin(object min)
        {
            _min = min;
            return this;
        }

        public ColumnBuilder WithMax(object max)
        {
            _max = max;
            return this;
        }

        public ColumnBuilder WithNulls()
        {
            _hasNulls = true;
            return this;
        }

        public Column Build()
        {
            var values = new List<object>();

            if (_max != null)
                values.Add(_max);

            if (_min != null)
                values.Add(_min);

            if (_hasNulls)
                values.Add(null);

            return new Column(_id, _index, _name, _type, values);
        }
    }
}
