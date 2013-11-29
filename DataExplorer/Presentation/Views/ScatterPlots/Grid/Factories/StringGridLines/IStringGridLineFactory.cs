using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Factories.StringGridLines
{
    public interface IStringGridLineFactory
    {
        IEnumerable<AxisGridLine> Create(IAxisMap map, List<object> values, double lower, double upper);
    }
}