using System;
using System.Collections.Generic;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Axes.Factories.DateTimeGridLines
{
    public interface IDayAxisGridLineFactory
    {
        IEnumerable<AxisGridLine> CreateQuarters(AxisMap map, DateTime lower, DateTime upper);

        IEnumerable<AxisGridLine> CreateMonths(AxisMap map, DateTime lower, DateTime upper);

        IEnumerable<AxisGridLine> CreateWeeks(AxisMap map, DateTime lower, DateTime upper);

        IEnumerable<AxisGridLine> CreateDays(AxisMap map, DateTime lower, DateTime upper);
    }
}
