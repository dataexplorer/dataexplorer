using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;
using DataExplorer.Infrastructure.Serializers.Properties;

namespace DataExplorer.Infrastructure.Serializers.Columns
{
    public class ColumnSerializer : IColumnSerializer
    {
        private const string ColumnTag = "column";
        private const string IdTag = "id";
        private const string IndexTag = "index";
        private const string NameTag = "name";
        private const string TypeTag = "type";

        private readonly IPropertySerializer _propertySerializer;

        public ColumnSerializer(IPropertySerializer propertySerializer)
        {
            _propertySerializer = propertySerializer;
        }

        public XElement Serialize(Column column)
        {
            var xColumn = new XElement(ColumnTag);

            SerializeProperty(xColumn, IdTag, column.Id);

            SerializeProperty(xColumn, IndexTag, column.Index);

            SerializeProperty(xColumn, NameTag, column.Name);

            SerializeProperty(xColumn, TypeTag, column.Type);
            
            return xColumn;
        }

        private void SerializeProperty<T>(XElement xColumn, string name, T value)
        {
            var xProperty = _propertySerializer.Serialize(name, value);

            xColumn.Add(xProperty);
        }

        public Column Deserialize(XElement xColumn, List<Row> rows)
        {
            var id = DeserializeProperty<int>(xColumn, IdTag);

            var index = DeserializeProperty<int>(xColumn, IndexTag);

            var name = DeserializeProperty<string>(xColumn, NameTag);

            var type = DeserializeProperty<Type>(xColumn, TypeTag);

            var values = rows.Select(p => p[index]).ToList();

            return new Column(id, index, name, type, values);
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
