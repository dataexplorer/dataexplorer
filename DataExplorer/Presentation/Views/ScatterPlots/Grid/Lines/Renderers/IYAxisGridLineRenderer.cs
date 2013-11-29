using System.Collections.Generic;
using System.Windows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Lines.Renderers
{
    public interface IYAxisGridLineRenderer
    {
        IEnumerable<CanvasLine> Render(IEnumerable<AxisGridLine> axisLines, Rect viewExtent, Size controlSize);
    }
}
