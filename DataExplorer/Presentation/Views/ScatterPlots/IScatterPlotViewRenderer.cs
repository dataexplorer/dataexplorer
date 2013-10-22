using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Core.Geometry;

namespace DataExplorer.Presentation.Views.ScatterPlots
{
    public interface IScatterPlotViewRenderer
    {
        List<CanvasCircle> RenderPlots(Size controlSize, Rect viewExtent, List<PlotDto> plots);
        Rect ResizeView(Size controlSize, Rect viewExtent);
    }
}
