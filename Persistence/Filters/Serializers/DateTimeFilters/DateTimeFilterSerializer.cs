using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Persistence.Projects;

namespace DataExplorer.Persistence.Filters.Serializers.DateTimeFilters
{
    public class DateTimeFilterSerializer : IDateTimeFilterSerializer
    {
        private const string FilterTag = "datetime-filter";
        private const string ColumnIdTag = "column-id";
        private const string LowerValueTag = "lower-value";
        private const string UpperValueTag = "upper-value";
        private const string IncludeNullTag = "include-null";

        private readonly IPropertySerializer _propertySerializer;

        public DateTimeFilterSerializer(IPropertySerializer propertySerializer)
        {
            _propertySerializer = propertySerializer;
        }

        public XElement Serialize(DateTimeFilter filter)
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

        public DateTimeFilter Deserialize(XElement xFilter, IEnumerable<Column> columns)
        {
            var id = DeserializeProperty<int>(xFilter, ColumnIdTag);

            var column = columns.First(p => p.Id == id);

            var lowerValue = DeserializeProperty<DateTime>(xFilter, LowerValueTag);

            var upperValue = DeserializeProperty<DateTime>(xFilter, UpperValueTag);

            var includeNull = DeserializeProperty<bool>(xFilter, IncludeNullTag);

            return new DateTimeFilter(column, lowerValue, upperValue, includeNull);
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
