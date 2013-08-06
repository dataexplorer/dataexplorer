using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using DataExplorer.Application.ScatterPlot;
using DataExplorer.Presentation.Core.Geometry;

namespace DataExplorer.Presentation.Views.ScatterPlot
{
    public interface IScatterPlotViewRenderer
    {
        List<Circle> RenderPlots(Size controlSize, Rect viewExtent, List<PlotDto> plots);
        Rect ResizeView(Size controlSize, Rect viewExtent);
    }
}
