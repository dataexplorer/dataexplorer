using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Persistence.Filters.Serializers
{
    public interface IFilterSetSerializer
    {
        XElement Serialize(IEnumerable<Filter> filters);

        IEnumerable<Filter> Deserialize(XElement xFilters, IEnumerable<Column> columns);
    }
}
