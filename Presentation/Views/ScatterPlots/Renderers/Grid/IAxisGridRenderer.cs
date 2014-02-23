using System;
using System.Collections.Generic;
using System.Windows;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Renderers.Grid
{
    public interface IAxisGridRenderer
    {
        IEnumerable<CanvasLine> RenderXAxisGridLines(IEnumerable<AxisGridLine> axisLines, Rect viewExtent, Size controlSize);

        IEnumerable<CanvasLine> RenderYAxisGridLines(IEnumerable<AxisGridLine> axisLines, Rect viewExtent, Size controlSize);

        IEnumerable<CanvasLabel> RenderXAxisGridLabels(IEnumerable<AxisGridLine> axisLines, Rect viewExtent, Size controlSize);

        IEnumerable<CanvasLabel> RenderYAxisGridLabels(IEnumerable<AxisGridLine> axisLines, Rect viewExtent, Size controlSize);
    }
}
