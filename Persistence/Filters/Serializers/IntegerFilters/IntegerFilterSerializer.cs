using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Persistence.Projects;

namespace DataExplorer.Persistence.Filters.Serializers.IntegerFilters
{
    public class IntegerFilterSerializer : IIntegerFilterSerializer
    {
        private const string FilterTag = "integer-filter";
        private const string ColumnIdTag = "column-id";
        private const string LowerValueTag = "lower-value";
        private const string UpperValueTag = "upper-value";
        private const string IncludeNullTag = "include-null";

        private readonly IPropertySerializer _propertySerializer;

        public IntegerFilterSerializer(IPropertySerializer propertySerializer)
        {
            _propertySerializer = propertySerializer;
        }

        public XElement Serialize(IntegerFilter filter)
        {
            var xFilter = new XElement(FilterTag);

            AddProperty(xFilter, ColumnIdTag, filter.Column.Id);

            AddProperty(xFilter, LowerValueTag, filter.LowerValue);

            AddProperty(xFilter, UpperValueTag, filter.UpperValue);

            AddProperty(xFilter, IncludeNullTag, filter.IncludeNull);

            return xFilter;
        }

        private void AddProperty<T>(XElement xElement, string name, T value)
        {
            var xProperty = _propertySerializer.Serialize(name, value);

            xElement.Add(xProperty);
        }

        public IntegerFilter Deserialize(XElement xFilter, IEnumerable<Column> columns)
        {
            var id = DeserializeProperty<int>(xFilter, ColumnIdTag);

            var column = columns.First(p => p.Id == id);

            var lowerValue = DeserializeProperty<int>(xFilter, LowerValueTag);

            var upperValue = DeserializeProperty<int>(xFilter, UpperValueTag);

            var includeNull = DeserializeProperty<bool>(xFilter, IncludeNullTag);

            return new IntegerFilter(column, lowerValue, upperValue, includeNull);
        }

        private T DeserializeProperty<T>(XElement xColumn, string name)
        {
            var xProperty = xColumn.Elements()
                .First(p => p.Name == name);

            var value = _propertySerializer.Deserialize<T>(xProperty);

            return value;
        }
    }
}
