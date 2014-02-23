using System.Collections.Generic;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Axes.Factories.FloatGridLines
{
    public interface IFloatGridLineFactory
    {
        IEnumerable<AxisGridLine> Create(AxisMap map, double lower, double upper);
    }
}