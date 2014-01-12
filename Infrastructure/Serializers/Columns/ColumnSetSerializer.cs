using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Infrastructure.Serializers.Columns
{
    public class ColumnSetSerializer : IColumnSetSerializer
    {
        private static readonly string ColumnsTag = "columns";

        private readonly IColumnSerializer _columnSerializer;

        public ColumnSetSerializer(IColumnSerializer columnSerializer)
        {
            _columnSerializer = columnSerializer;
        }

        public XElement Serialize(IEnumerable<Column> columns)
        {
            var xColumns = new XElement(ColumnsTag);

            foreach (var column in columns)
            {
                var xSource = _columnSerializer.Serialize(column);

                xColumns.Add(xSource);
            }

            return xColumns;
        }

        public IEnumerable<Column> Deserialize(XElement xColumns, List<Row> rows)
        {
            var columns = new List<Column>();

            foreach (var xColumn in xColumns.Elements())
            {
                var column = _columnSerializer.Deserialize(xColumn, rows);

                columns.Add(column);
            }

            return columns;
        }
    }
}
