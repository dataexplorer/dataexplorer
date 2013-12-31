using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Infrastructure.Serializers.Filters
{
    public interface IFilterSerializer
    {
        XElement Serialize(Filter filter);

        Filter Deserialize(XElement xFilter, IEnumerable<Column> columns);
    }
}
