using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Persistence.Filters.Serializers.BooleanFilters
{
    public interface IBooleanFilterSerializer
    {
        XElement Serialize(BooleanFilter filter);

        BooleanFilter Deserialize(XElement xFilter, List<Column> columns);
    }
}
