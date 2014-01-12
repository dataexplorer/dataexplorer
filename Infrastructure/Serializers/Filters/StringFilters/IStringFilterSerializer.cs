using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters.StringFilters;

namespace DataExplorer.Infrastructure.Serializers.Filters.StringFilters
{
    public interface IStringFilterSerializer
    {
        XElement Serialize(StringFilter filter);

        StringFilter Deserialize(XElement xFilter, IEnumerable<Column> columns);
    }
}
