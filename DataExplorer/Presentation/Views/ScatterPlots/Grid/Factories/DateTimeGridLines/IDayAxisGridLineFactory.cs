using System;
using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Factories.DateTimeGridLines
{
    public interface IDayAxisGridLineFactory
    {
        IEnumerable<AxisGridLine> CreateQuarters(IAxisMap map, DateTime lower, DateTime upper);

        IEnumerable<AxisGridLine> CreateMonths(IAxisMap map, DateTime lower, DateTime upper);

        IEnumerable<AxisGridLine> CreateWeeks(IAxisMap map, DateTime lower, DateTime upper);

        IEnumerable<AxisGridLine> CreateDays(IAxisMap map, DateTime lower, DateTime upper);
    }
}
