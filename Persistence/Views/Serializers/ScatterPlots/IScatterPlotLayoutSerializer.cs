using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Persistence.Views.Serializers.ScatterPlots
{
    public interface IScatterPlotLayoutSerializer
    {
        XElement Serialize(ScatterPlotLayout layout);

        ScatterPlotLayout Deserialize(XElement xLayout, IEnumerable<Column> columns);
    }
}
