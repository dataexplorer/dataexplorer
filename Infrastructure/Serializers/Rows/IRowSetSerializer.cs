using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Infrastructure.Serializers.Rows
{
    public interface IRowSetSerializer
    {
        XElement Serialize(IEnumerable<Row> rows, IEnumerable<Column> columns);

        IEnumerable<Row> Deserialize(XElement xRows, List<Type> dataTypes);
    }
}
