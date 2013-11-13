using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Lines.Renderers
{
    public interface IYAxisGridLineRenderer
    {
        IEnumerable<CanvasLine> Render(IEnumerable<AxisGridLine> axisLines, Rect viewExtent, Size controlSize);
    }
}
