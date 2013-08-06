using System.Collections.Generic;
using System.Windows;

namespace DataExplorer.Application.ScatterPlot
{
    public interface IScatterPlotService
    {
        Rect GetViewExtent();
        void SetViewExtent(Rect viewExtent);
        List<PlotDto> GetPlots();
    }
}