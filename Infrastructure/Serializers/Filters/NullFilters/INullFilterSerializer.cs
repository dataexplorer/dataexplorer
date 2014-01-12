using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters.NullFilters;

namespace DataExplorer.Infrastructure.Serializers.Filters.NullFilters
{
    public interface INullFilterSerializer
    {
        XElement Serialize(NullFilter filter);

        NullFilter Deserialize(XElement xFilter, IEnumerable<Column> columns);
    }
}
