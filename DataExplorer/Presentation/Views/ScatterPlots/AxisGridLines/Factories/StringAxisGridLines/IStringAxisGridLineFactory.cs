using System.Collections.Generic;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories.StringAxisGridLines
{
    public interface IStringAxisGridLineFactory
    {
        IEnumerable<AxisGridLine> Create();
    }
}