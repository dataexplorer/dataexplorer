using System.Collections.Generic;
using System.Windows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Lines.Renderers
{
    public class YAxisGridLineRenderer : IYAxisGridLineRenderer
    {
        private const double MarginHeight = 45d;

        private readonly IValueScaler _valueScaler;

        public YAxisGridLineRenderer(IValueScaler valueScaler)
        {
            _valueScaler = valueScaler;
        }
        
        public IEnumerable<CanvasLine> Render(IEnumerable<AxisGridLine> axisLines, Rect viewExtent, Size controlSize)
        {
            foreach (var axisLine in axisLines)
                yield return RenderLine(axisLine, viewExtent, controlSize);
        }

        private CanvasLine RenderLine(AxisGridLine axisGridLine, Rect viewExtent, Size controlSize)
        {
            var scaledPosition = _valueScaler.Scale(axisGridLine.Position, viewExtent.Top, viewExtent.Height, 0d, controlSize.Height);

            var canvasLine = new CanvasLine()
            {
                X1 = MarginHeight,
                Y1 = controlSize.Height - scaledPosition,
                X2 = controlSize.Width,
                Y2 = controlSize.Height - scaledPosition
            };

            return canvasLine;
        }
    }
}
