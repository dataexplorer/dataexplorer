using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Persistence.Columns.Serializers
{
    public interface IColumnSetSerializer
    {
        XElement Serialize(IEnumerable<Column> columns);

        IEnumerable<Column> Deserialize(XElement xColumns, List<Row> rows);
    }
}
