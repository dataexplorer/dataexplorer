using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Factories.DateTimeGridLines
{
    public interface IDateTimeGridLineFactory
    {
        IEnumerable<AxisGridLine> Create(IAxisMap map, double lower, double upper);
    }
}