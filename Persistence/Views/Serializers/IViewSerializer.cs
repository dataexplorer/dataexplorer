using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Views;

namespace DataExplorer.Persistence.Views.Serializers
{
    public interface IViewSerializer
    {
        XElement Serialize(View view);

        View Deserialize(XElement xView, IEnumerable<Column> columns);
    }
}
