using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Persistence.Filters.Serializers.ImageFilters
{
    public interface IImageFilterSerializer
    {
        XElement Serialize(ImageFilter filter);

        ImageFilter Deserialize(XElement xFilter, List<Column> columns);
    }
}
