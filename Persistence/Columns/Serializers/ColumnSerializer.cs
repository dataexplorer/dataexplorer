using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Semantics;
using DataExplorer.Persistence.Common.Serializers;

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
        private const string DataTypeTag = "data-type";
        private const string SemanticTypeTag = "semantic-type";


        public ColumnSerializer(
            IPropertySerializer propertySerializer) 
            : base(propertySerializer)
        {
            
        }

        public XElement Serialize(Column column)
        {
            var xColumn = new XElement(ColumnTag);

            AddProperty(xColumn, IdTag, column.Id);

            AddProperty(xColumn, IndexTag, column.Index);

            AddProperty(xColumn, NameTag, column.Name);

            AddProperty(xColumn, DataTypeTag, column.DataType);

            AddProperty(xColumn, SemanticTypeTag, column.SemanticType);
            
            return xColumn;
        }

        public Column Deserialize(XElement xColumn, List<Row> rows)
        {
            var id = GetProperty<int>(xColumn, IdTag);

            var index = GetProperty<int>(xColumn, IndexTag);

            var name = GetProperty<string>(xColumn, NameTag);

            var dataType = GetProperty<Type>(xColumn, DataTypeTag);

            var semanticType = GetProperty<SemanticType>(xColumn, SemanticTypeTag);

            var values = rows.Select(p => p[index]).ToList();

            // TODO: Try to move the aggregation logic below into a common location
            var isComparable = !(dataType == typeof(BitmapImage));

            var min = isComparable
                ? values.Min()
                : null;

            var max = isComparable
                ? values.Max()
                : null;

            var hasNulls = values
                .Any(p => p == null);

            return new Column(id, index, name, dataType, semanticType, values, min, max, hasNulls);
        }
    }
}
