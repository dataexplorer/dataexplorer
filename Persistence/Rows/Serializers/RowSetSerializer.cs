using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Persistence.Rows.Serializers
{
    public class RowSetSerializer : IRowSetSerializer
    {
        private static readonly string RowsTag = "rows";

        private readonly IRowSerializer _rowSerializer;

        public RowSetSerializer(IRowSerializer rowSerializer)
        {
            _rowSerializer = rowSerializer;
        }

        public XElement Serialize(IEnumerable<Row> rows, IEnumerable<Column> columns)
        {
            var xRows = new XElement(RowsTag);

            foreach (var row in rows)
            {
                var xSource = _rowSerializer.Serialize(row, columns);

                xRows.Add(xSource);
            }

            return xRows;
        }

        public IEnumerable<Row> Deserialize(XElement xRows, List<Type> dataTypes)
        {
            var rows = new List<Row>();

            foreach (var xRow in xRows.Elements())
            {
                var row = _rowSerializer.Deserialize(xRow, dataTypes);

                rows.Add(row);
            }

            return rows;
        }
    }
}
