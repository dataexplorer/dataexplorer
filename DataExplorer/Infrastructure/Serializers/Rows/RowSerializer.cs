using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;
using DataExplorer.Infrastructure.Serializers.Properties;

namespace DataExplorer.Infrastructure.Serializers.Rows
{
    public class RowSerializer : IRowSerializer
    {
        private const string RowTag = "row";
        private const string IdTag = "id";
        private const string FieldsTag = "fields";

        private readonly IPropertySerializer _propertySerializer;

        public RowSerializer(IPropertySerializer propertySerializer)
        {
            _propertySerializer = propertySerializer;
        }

        public XElement Serialize(Row row, IEnumerable<Column> columns)
        {
            var xRow = new XElement(RowTag);

            SerializeProperty(xRow, IdTag, row.Id);

            SerializeFields(xRow, row, columns.ToList());

            return xRow;
        }

        private void SerializeProperty<T>(XElement xColumn, string name, T value)
        {
            var xProperty = _propertySerializer.Serialize(name, value);

            xColumn.Add(xProperty);
        }

        private void SerializeFields(XElement xRow, Row row, List<Column> columns)
        {
            var xFields = new XElement(FieldsTag);

            for (int i = 0; i < row.Fields.Count(); i++)
            {
                var column = columns[i];

                var fieldName = GetSafeXmlTagName(column.Name);

                var field = row[i];

                var xField = _propertySerializer.Serialize(fieldName, field);

                xFields.Add(xField);
            }

            xRow.Add(xFields);
        }

        private string GetSafeXmlTagName(string name)
        {
            var regex = new Regex("[^a-zA-Z0-9 -]");

            var safeName = regex.Replace(name, "")
                .Replace(' ', '-')
                .ToLower();

            return safeName;
        }

        public Row Deserialize(XElement xRow, IEnumerable<Type> columns)
        {
            var id = DeserializeProperty<int>(xRow, IdTag);

            var fields = DeserializeFields(xRow, columns.ToList());

            var row = new Row(id, fields);

            return row;
        }

        private T DeserializeProperty<T>(XElement xRow, string name)
        {
            var xProperty = xRow.Elements()
                .First(p => p.Name == name);

            var value = _propertySerializer.Deserialize<T>(xProperty);

            return value;
        }

        private IEnumerable<object> DeserializeFields(XElement xRow, List<Type> dataTypes)
        {
            var xFields = xRow.Elements()
                .First(p => p.Name == FieldsTag)
                .Elements()
                .ToList();

            var fields = new List<object>();

            for (int i = 0; i < xFields.Count; i++)
            {
                var xField = xFields[i];

                var dataType = dataTypes[i];

                var field = _propertySerializer.Deserialize(xField, dataType);

                fields.Add(field);
            }

            return fields;
        }
    }
}
