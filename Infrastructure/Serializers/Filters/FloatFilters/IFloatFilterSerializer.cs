using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters.FloatFilters;

namespace DataExplorer.Infrastructure.Serializers.Filters.FloatFilters
{
    public interface IFloatFilterSerializer
    {
        XElement Serialize(FloatFilter filter);

        FloatFilter Deserialize(XElement xFilter, IEnumerable<Column> columns);
    }
}
