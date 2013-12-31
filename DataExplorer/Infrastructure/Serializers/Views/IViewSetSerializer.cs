using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Views;

namespace DataExplorer.Infrastructure.Serializers.Views
{
    public interface IViewSetSerializer
    {
        XElement Serialize(IEnumerable<IView> views);

        IEnumerable<IView> Deserialize(XElement xViews, IEnumerable<Column> columns);
    }
}
