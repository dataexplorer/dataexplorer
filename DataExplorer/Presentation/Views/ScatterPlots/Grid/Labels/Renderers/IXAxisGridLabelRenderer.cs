using System.Collections.Generic;
using System.Windows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Labels.Renderers
{
    public interface IXAxisGridLabelRenderer
    {
        IEnumerable<CanvasLabel> Render(IEnumerable<AxisGridLine> axisLines, Rect viewExtent, Size controlSize);
    }
}
