using System;
using System.Collections.Generic;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Axes.Factories.DateTimeGridLines
{
    public interface ISecondAxisGridLineFactory
    {
        IEnumerable<AxisGridLine> CreateFourHours(AxisMap map, DateTime lower, DateTime upper);

        IEnumerable<AxisGridLine> CreateHours(AxisMap map, DateTime lower, DateTime upper);

        IEnumerable<AxisGridLine> CreateTenMinutes(AxisMap map, DateTime lower, DateTime upper);

        IEnumerable<AxisGridLine> CreateMinutes(AxisMap map, DateTime lower, DateTime upper);

        IEnumerable<AxisGridLine> CreateTenSeconds(AxisMap map, DateTime lower, DateTime upper);

        IEnumerable<AxisGridLine> CreateSeconds(AxisMap map, DateTime lower, DateTime upper);


    }
}
