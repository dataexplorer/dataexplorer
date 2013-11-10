using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Factories.IntegerAxisGridLines
{
    public interface IIntegerAxisGridLineFactory
    {
        IEnumerable<AxisGridLine> Create(IAxisMap map, double lower, double upper);
    }
}