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
    public interface IColumnSetSerializer
    {
        XElement Serialize(IEnumerable<Column> columns);

        IEnumerable<Column> Deserialize(XElement xColumns, List<Row> rows);
    }
}
