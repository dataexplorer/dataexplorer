using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Factories.StringAxisGridLines
{
    public interface IStringAxisGridLineFactory
    {
        IEnumerable<AxisGridLine> Create(IAxisMap map, List<object> values, double lower, double upper);
    }
}