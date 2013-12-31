using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Infrastructure.Serializers.Rows
{
    public interface IRowSerializer
    {
        XElement Serialize(Row row, IEnumerable<Column> columns);

        Row Deserialize(XElement xRow, IEnumerable<Type> dataTypes);
    }
}
