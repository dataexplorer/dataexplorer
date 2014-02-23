using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Views;

namespace DataExplorer.Persistence.Views.Serializers
{
    public interface IViewSetSerializer
    {
        XElement Serialize(IEnumerable<View> views);

        IEnumerable<View> Deserialize(XElement xViews, List<Column> columns);
    }
}
