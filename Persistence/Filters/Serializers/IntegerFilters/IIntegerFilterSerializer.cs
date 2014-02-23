using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Persistence.Filters.Serializers.IntegerFilters
{
    public interface IIntegerFilterSerializer
    {
        XElement Serialize(IntegerFilter filter);

        IntegerFilter Deserialize(XElement xFilter, IEnumerable<Column> columns);
    }
}
