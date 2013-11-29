using System;
using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Factories.DateTimeGridLines
{
    public interface ISecondAxisGridLineFactory
    {
        IEnumerable<AxisGridLine> CreateFourHours(IAxisMap map, DateTime lower, DateTime upper);

        IEnumerable<AxisGridLine> CreateHours(IAxisMap map, DateTime lower, DateTime upper);

        IEnumerable<AxisGridLine> CreateTenMinutes(IAxisMap map, DateTime lower, DateTime upper);

        IEnumerable<AxisGridLine> CreateMinutes(IAxisMap map, DateTime lower, DateTime upper);

        IEnumerable<AxisGridLine> CreateTenSeconds(IAxisMap map, DateTime lower, DateTime upper);

        IEnumerable<AxisGridLine> CreateSeconds(IAxisMap map, DateTime lower, DateTime upper);


    }
}
