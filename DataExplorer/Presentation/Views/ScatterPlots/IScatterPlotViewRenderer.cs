using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots
{
    public interface IScatterPlotViewRenderer
    {
        List<CanvasCircle> RenderPlots(Size controlSize, Rect viewExtent, List<PlotDto> plots);

        CanvasXAxisLabel RenderXAxisLabel(Size controlSize, string labelText);
        
        CanvasYAxisLabel RenderYAxisLabel(Size controlSize, string labelText);
    }
}
