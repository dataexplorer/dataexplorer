using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Infrastructure.Serializers.Properties;

namespace DataExplorer.Infrastructure.Serializers.Filters.StringFilters
{
    public class StringFilterSerializer : IStringFilterSerializer
    {
        private const string FilterTag = "integer-filter";
        private const string ColumnIdTag = "column-id";
        private const string ValueTag = "value";
        private const string IncludeNullTag = "include-null";
        
        private readonly IPropertySerializer _propertySerializer;

        public StringFilterSerializer(IPropertySerializer propertySerializer)
        {
            _propertySerializer = propertySerializer;
        }

        public XElement Serialize(StringFilter filter)
        {
            var xFilter = new XElement(FilterTag);

            AddProperty(xFilter, ColumnIdTag, filter.Column.Id);

            AddProperty(xFilter, ValueTag, filter.Value);

            AddProperty(xFilter, IncludeNullTag, filter.IncludeNull);
            
            return xFilter;
        }

        private void AddProperty<T>(XElement xElement, string name, T value)
        {
            var xProperty = _propertySerializer.Serialize(name, value);

            xElement.Add(xProperty);
        }

        public StringFilter Deserialize(XElement xFilter, IEnumerable<Column> columns)
        {
            var id = DeserializeProperty<int>(xFilter, ColumnIdTag);

            var column = columns.First(p => p.Id == id);

            var value = DeserializeProperty<string>(xFilter, ValueTag);

            var includeNull = DeserializeProperty<bool>(xFilter, IncludeNullTag);

            return new StringFilter(column, value, includeNull);
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
