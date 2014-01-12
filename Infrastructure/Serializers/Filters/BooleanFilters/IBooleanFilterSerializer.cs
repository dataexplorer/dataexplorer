using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Filters.BooleanFilters;

namespace DataExplorer.Infrastructure.Serializers.Filters.BooleanFilters
{
    public interface IBooleanFilterSerializer
    {
        XElement Serialize(BooleanFilter filter);

        BooleanFilter Deserialize(XElement xFilter, IEnumerable<Column> columns);
    }
}
