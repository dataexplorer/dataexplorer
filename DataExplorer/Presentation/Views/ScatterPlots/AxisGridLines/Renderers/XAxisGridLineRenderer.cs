using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Renderers
{
    public class XAxisGridLineRenderer : IXAxisGridLineRenderer
    {
        private const double MarginHeight = 45d;

        private readonly IValueScaler _valueScaler;

        public XAxisGridLineRenderer(IValueScaler valueScaler)
        {
            _valueScaler = valueScaler;
        }
        
        public IEnumerable<CanvasLine> Render(IEnumerable<AxisLine> axisLines, Rect viewExtent, Size controlSize)
        {
            foreach (var axisLine in axisLines)
                yield return RenderLine(axisLine, viewExtent, controlSize);
                   
        }

        private CanvasLine RenderLine(AxisLine axisLine, Rect viewExtent, Size controlSize)
        {
            var scaledPosition = _valueScaler.Scale(axisLine.Position, viewExtent.Left, viewExtent.Width, 0d, controlSize.Width);

            var canvasLine = new CanvasLine()
            {
                X1 = scaledPosition,
                Y1 = 0,
                X2 = scaledPosition,
                Y2 = controlSize.Height - MarginHeight
            };

            return canvasLine;
        }
    }
}
