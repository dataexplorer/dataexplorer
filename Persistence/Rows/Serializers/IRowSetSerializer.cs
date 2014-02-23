using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Persistence.Rows.Serializers
{
    public interface IRowSetSerializer
    {
        XElement Serialize(IEnumerable<Row> rows, IEnumerable<Column> columns);

        IEnumerable<Row> Deserialize(XElement xRows, List<Type> dataTypes);
    }
}
