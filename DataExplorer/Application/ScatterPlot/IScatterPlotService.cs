using System.Collections.Generic;
using System.Windows;

namespace DataExplorer.Application.ScatterPlot
{
    public interface IScatterPlotService
    {
        event ScatterPlotChangedEventHandler ScatterPlotChanged;
        Rect GetViewExtent();
        void SetViewExtent(Rect viewExtent);
        List<PlotDto> GetPlots();
    }
}