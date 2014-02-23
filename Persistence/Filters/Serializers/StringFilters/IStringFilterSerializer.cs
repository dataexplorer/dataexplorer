using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Persistence.Filters.Serializers.StringFilters
{
    public interface IStringFilterSerializer
    {
        XElement Serialize(StringFilter filter);

        StringFilter Deserialize(XElement xFilter, List<Column> columns);
    }
}
