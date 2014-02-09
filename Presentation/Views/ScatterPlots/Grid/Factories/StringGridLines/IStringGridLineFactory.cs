using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Factories.StringGridLines
{
    public interface IStringGridLineFactory
    {
        IEnumerable<AxisGridLine> Create(AxisMap map, List<object> values, double lower, double upper);
    }
}