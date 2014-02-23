using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Persistence.Views.Serializers.ScatterPlots
{
    public interface IScatterPlotSerializer
    {
        XElement Serialize(ScatterPlot scatterPlot);

        ScatterPlot Deserialize(XElement xView, IEnumerable<Column> columns);
    }
}
