using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Infrastructure.Serializers.Filters
{
    public interface IFilterSetSerializer
    {
        XElement Serialize(IEnumerable<Filter> filters);

        IEnumerable<Filter> Deserialize(XElement xFilters, IEnumerable<Column> columns);
    }
}
