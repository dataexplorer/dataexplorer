using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories.BooleanAxisGridLines
{
    public interface IBooleanAxisGridLineFactory
    {
        IEnumerable<AxisGridLine> Create(IAxisMap map, double lower, double upper);
    }
}