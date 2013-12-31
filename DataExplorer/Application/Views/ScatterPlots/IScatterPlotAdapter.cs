using System.Collections.Generic;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots
{
    public interface IScatterPlotAdapter
    {
        List<PlotDto> Adapt(List<Plot> plots);
    }
}
