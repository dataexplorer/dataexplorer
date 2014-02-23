using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;
using DataExplorer.Persistence.Projects;

namespace DataExplorer.Persistence.Rows.Serializers
{
    public class RowSerializer 
        : BaseSerializer,
        IRowSerializer
    {
        private const string RowTag = "row";
        private const string IdTag = "id";
        private const string FieldsTag = "fields";

        public RowSerializer(IPropertySerializer propertySerializer) 
            : base(propertySerializer)
        {
            
        }

        public XElement Serialize(Row row, IEnumerable<Column> columns)
        {
            var xRow = new XElement(RowTag);

            AddProperty(xRow, IdTag, row.Id);

            SerializeFields(xRow, row, columns.ToList());

            return xRow;
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
            var id = GetProperty<int>(xRow, IdTag);

            var fields = DeserializeFields(xRow, columns.ToList());

            var row = new Row(id, fields);

            return row;
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
