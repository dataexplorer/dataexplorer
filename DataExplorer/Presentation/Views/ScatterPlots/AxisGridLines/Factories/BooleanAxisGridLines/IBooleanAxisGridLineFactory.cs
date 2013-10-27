using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories.BooleanAxisGridLines
{
    public interface IBooleanAxisGridLineFactory
    {
        IEnumerable<AxisLine> Create(IAxisMap map);
    }
}