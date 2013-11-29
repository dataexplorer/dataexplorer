using System.Collections.Generic;
using System.Windows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Labels.Renderers
{
    public class YAxisGridLabelRenderer : IYAxisGridLabelRenderer
    {
        private const double MarginWidth = 25d;

        private readonly IValueScaler _valueScaler;

        public YAxisGridLabelRenderer(IValueScaler valueScaler)
        {
            _valueScaler = valueScaler;
        }

        public IEnumerable<CanvasLabel> Render(IEnumerable<AxisGridLine> axisLines, Rect viewExtent, Size controlSize)
        {
            foreach (var axisLine in axisLines)
                yield return RenderLabel(axisLine, viewExtent, controlSize);
        }

        private CanvasLabel RenderLabel(AxisGridLine axisGridLine, Rect viewExtent, Size controlSize)
        {
            var scaledPosition = _valueScaler.Scale(axisGridLine.Position, viewExtent.Top, viewExtent.Height, 0d, controlSize.Height);

            var canvasLine = new CanvasLabel()
            {
                Text = axisGridLine.LabelName,
                X = MarginWidth,
                Y = controlSize.Height - scaledPosition,
                IsRotated = true
                
            };

            return canvasLine;
        }
    }
}
