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
        private const string ValuesTag = "values";

        private readonly IPropertySerializer _propertySerializer;

        public BooleanFilterSerializer(IPropertySerializer propertySerializer)
        {
            _propertySerializer = propertySerializer;
        }

        public XElement Serialize(BooleanFilter filter)
        {
            var xFilter = new XElement(FilterTag);

            AddProperty(xFilter, ColumnIdTag, filter.Column.Id);

            AddList(xFilter, ValuesTag, filter.Values);

            return xFilter;
        }

        private void AddProperty<T>(XElement xElement, string name, T value)
        {
            var xProperty = _propertySerializer.Serialize(name, value);

            xElement.Add(xProperty);
        }

        private void AddList<T>(XElement xElement, string name, List<T> values)
        {
            var xList = _propertySerializer.SerializeList(name, values);

            xElement.Add(xList);
        }

        public BooleanFilter Deserialize(XElement xFilter, IEnumerable<Column> columns)
        {
            var id = DeserializeProperty<int>(xFilter, ColumnIdTag);

            var column = columns.First(p => p.Id == id);

            var values = DeserializeList<bool?>(xFilter, ValuesTag);

            return new BooleanFilter(column, values);
        }

        private T DeserializeProperty<T>(XElement xColumn, string name)
        {
            var xProperty = xColumn.Elements()
                .First(p => p.Name == name);

            var value = _propertySerializer.Deserialize<T>(xProperty);

            return value;
        }

        private List<T> DeserializeList<T>(XElement xColumn, string name)
        {
            var xProperty = xColumn.Elements()
                .First(p => p.Name == name);

            var value = _propertySerializer.DeserializeList<T>(xProperty);

            return value;
        }
    }
}
