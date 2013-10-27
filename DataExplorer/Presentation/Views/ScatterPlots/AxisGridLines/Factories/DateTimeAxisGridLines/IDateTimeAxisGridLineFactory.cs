using System.Collections.Generic;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories.DateTimeAxisGridLines
{
    public interface IDateTimeAxisGridLineFactory
    {
        IEnumerable<AxisLine> Create();
    }
}