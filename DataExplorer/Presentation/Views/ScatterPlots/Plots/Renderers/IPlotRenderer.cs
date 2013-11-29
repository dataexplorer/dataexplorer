using System.Collections.Generic;
using System.Windows;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Plots.Renderers
{
    public interface IPlotRenderer
    {
        List<CanvasItem> RenderPlots(Size controlSize, Rect viewExtent, List<PlotDto> plots);
    }
}