using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters.IntegerFilters;

namespace DataExplorer.Infrastructure.Serializers.Filters.IntegerFilters
{
    public interface IIntegerFilterSerializer
    {
        XElement Serialize(IntegerFilter filter);

        IntegerFilter Deserialize(XElement xFilter, IEnumerable<Column> columns);
    }
}
