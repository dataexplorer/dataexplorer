using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Semantics;

namespace DataExplorer.Domain.Tests.Columns
{
    public class ColumnBuilder
    {
        private int _id;
        private int _index;
        private string _name;
        private Type _dataType;
        private SemanticType _semanticType;
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

        public ColumnBuilder WithDataType(Type dataType)
        {
            _dataType = dataType;
            return this;
        }

        public ColumnBuilder WithSemanticType(SemanticType semanticType)
        {
            _semanticType = semanticType;
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

            var isComparable = !(_dataType == typeof (BitmapImage));

            var min = isComparable 
                ? values.Min()
                : null;

            var max = isComparable 
                ? values.Max()
                : null;

            var hasNulls = values
                .Any(p => p == null);

            return new Column(_id, _index, _name, _dataType, _semanticType, values, min, max, hasNulls);
        }
    }
}
