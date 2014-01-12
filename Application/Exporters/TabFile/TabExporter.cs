using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Application.Exporters.TabFile
{
    public class TabExporter : ITabExporter
    {
        public string Export(IEnumerable<Column> columns, IEnumerable<Row> rows)
        {
            var builder = new StringBuilder();

            builder.AppendLine(GetColumnHeaderLine(columns));

            foreach (var row in rows)
                builder.AppendLine(GetRowLine(row));

            return builder.ToString();
        }

        private static string GetColumnHeaderLine(IEnumerable<Column> columns)
        {
            var columnNames = columns.Select(p => p.Name);

            return string.Join("\t", columnNames);
        }

        private static string GetRowLine(Row row)
        {
            var fields = row.Fields.Select(p => GetField(p));

            return string.Join("\t", fields);
        }

        private static string GetField(object field)
        {
            if (field == null)
                return string.Empty;

            return field.ToString();
        }
    }
}
