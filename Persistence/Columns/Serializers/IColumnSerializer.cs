using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Persistence.Columns.Serializers
{
    public interface IColumnSerializer
    {
        XElement Serialize(Column column);

        Column Deserialize(XElement xColumn, List<Row> rows);
    }
}
