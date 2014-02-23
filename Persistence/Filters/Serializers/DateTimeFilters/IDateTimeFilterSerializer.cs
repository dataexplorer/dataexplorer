using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Persistence.Filters.Serializers.DateTimeFilters
{
    public interface IDateTimeFilterSerializer
    {
        XElement Serialize(DateTimeFilter filter);

        DateTimeFilter Deserialize(XElement xFilter, List<Column> columns);
    }
}
