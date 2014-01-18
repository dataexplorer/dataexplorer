using System;
using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Factories.DateTimeGridLines
{
    public interface IDayAxisGridLineFactory
    {
        IEnumerable<AxisGridLine> CreateQuarters(AxisMap map, DateTime lower, DateTime upper);

        IEnumerable<AxisGridLine> CreateMonths(AxisMap map, DateTime lower, DateTime upper);

        IEnumerable<AxisGridLine> CreateWeeks(AxisMap map, DateTime lower, DateTime upper);

        IEnumerable<AxisGridLine> CreateDays(AxisMap map, DateTime lower, DateTime upper);
    }
}
