using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Factories.DateTimeGridLines
{
    public interface IMinMaxDateTimeAxisGridLineFactory
    {
        IEnumerable<AxisGridLine> Create(AxisMap map);
    }
}
