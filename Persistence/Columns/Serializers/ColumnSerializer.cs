using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;
using DataExplorer.Persistence.Projects;

namespace DataExplorer.Persistence.Columns.Serializers
{
    public class ColumnSerializer 
        : BaseSerializer,
        IColumnSerializer
    {
        private const string ColumnTag = "column";
        private const string IdTag = "id";
        private const string IndexTag = "index";
        private const string NameTag = "name";
        private const string TypeTag = "type";

        public ColumnSerializer(IPropertySerializer propertySerializer) 
            : base(propertySerializer)
        {
            
        }

        public XElement Serialize(Column column)
        {
            var xColumn = new XElement(ColumnTag);

            AddProperty(xColumn, IdTag, column.Id);

            AddProperty(xColumn, IndexTag, column.Index);

            AddProperty(xColumn, NameTag, column.Name);

            AddProperty(xColumn, TypeTag, column.Type);
            
            return xColumn;
        }

        public Column Deserialize(XElement xColumn, List<Row> rows)
        {
            var id = GetProperty<int>(xColumn, IdTag);

            var index = GetProperty<int>(xColumn, IndexTag);

            var name = GetProperty<string>(xColumn, NameTag);

            var type = GetProperty<Type>(xColumn, TypeTag);

            var values = rows.Select(p => p[index]).ToList();

            return new Column(id, index, name, type, values);
        }
    }
}
