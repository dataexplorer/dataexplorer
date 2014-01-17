using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters.BooleanFilters;
using DataExplorer.Infrastructure.Serializers.Properties;

namespace DataExplorer.Infrastructure.Serializers.Filters.BooleanFilters
{
    public class BooleanFilterSerializer : IBooleanFilterSerializer
    {
        private const string FilterTag = "boolean-filter";
        private const string ColumnIdTag = "column-id";
        private const string IncludeTrueTag = "include-true";
        private const string IncludeFalseTag = "include-false";
        private const string IncludeNullTag = "include-null";

        private readonly IPropertySerializer _propertySerializer;

        public BooleanFilterSerializer(IPropertySerializer propertySerializer)
        {
            _propertySerializer = propertySerializer;
        }

        public XElement Serialize(BooleanFilter filter)
        {
            var xFilter = new XElement(FilterTag);

            AddProperty(xFilter, ColumnIdTag, filter.Column.Id);

            AddProperty(xFilter, IncludeTrueTag, filter.IncludeTrue);

            AddProperty(xFilter, IncludeFalseTag, filter.IncludeFalse);

            AddProperty(xFilter, IncludeNullTag, filter.IncludeNull);
            
            return xFilter;
        }

        private void AddProperty<T>(XElement xElement, string name, T value)
        {
            var xProperty = _propertySerializer.Serialize(name, value);

            xElement.Add(xProperty);
        }

        public BooleanFilter Deserialize(XElement xFilter, IEnumerable<Column> columns)
        {
            var id = DeserializeProperty<int>(xFilter, ColumnIdTag);

            var column = columns.First(p => p.Id == id);

            var includeTrue = DeserializeProperty<bool>(xFilter, IncludeTrueTag);

            var includeFalse = DeserializeProperty<bool>(xFilter, IncludeFalseTag);

            var includeNull = DeserializeProperty<bool>(xFilter, IncludeNullTag);
            
            return new BooleanFilter(column, includeTrue, includeFalse, includeNull);
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
