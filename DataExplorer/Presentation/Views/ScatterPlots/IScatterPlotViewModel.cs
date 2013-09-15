using System.Collections.Generic;
using DataExplorer.Presentation.Core.Geometry;

namespace DataExplorer.Presentation.Views.ScatterPlots
{
    public interface IScatterPlotViewModel
    {
        List<Circle> Plots { get; }
    }
}