using System.Collections.Generic;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Axes.Factories.DateTimeGridLines
{
    public interface IMinMaxDateTimeAxisGridLineFactory
    {
        IEnumerable<AxisGridLine> Create(AxisMap map);
    }
}
