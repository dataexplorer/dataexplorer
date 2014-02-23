using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Lines.Renderers
{
    public interface IAxisGridRenderer
    {
        IEnumerable<CanvasLine> RenderXAxisGridLines(IEnumerable<AxisGridLine> axisLines, Rect viewExtent, Size controlSize);

        IEnumerable<CanvasLine> RenderYAxisGridLines(IEnumerable<AxisGridLine> axisLines, Rect viewExtent, Size controlSize);

        IEnumerable<CanvasLabel> RenderXAxisGridLabels(IEnumerable<AxisGridLine> axisLines, Rect viewExtent, Size controlSize);

        IEnumerable<CanvasLabel> RenderYAxisGridLabels(IEnumerable<AxisGridLine> axisLines, Rect viewExtent, Size controlSize);
    }
}
