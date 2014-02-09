using System;
using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Factories.DateTimeGridLines
{
    public interface IYearAxisGridLineFactory
    {
        IEnumerable<AxisGridLine> Create(AxisMap map, DateTime lower, DateTime upper, int step);
    }
}
