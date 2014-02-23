using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Persistence.Filters.Serializers.FloatFilters
{
    public interface IFloatFilterSerializer
    {
        XElement Serialize(FloatFilter filter);

        FloatFilter Deserialize(XElement xFilter, List<Column> columns);
    }
}
