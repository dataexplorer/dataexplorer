using System.Collections.Generic;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories.IntegerAxisGridLines
{
    public interface IIntegerAxisGridLineFactory
    {
        IEnumerable<AxisGridLine> Create();
    }
}