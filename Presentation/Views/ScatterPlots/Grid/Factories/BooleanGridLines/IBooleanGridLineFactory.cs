using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Factories.BooleanGridLines
{
    public interface IBooleanGridLineFactory
    {
        IEnumerable<AxisGridLine> Create(AxisMap map, double lower, double upper);
    }
}