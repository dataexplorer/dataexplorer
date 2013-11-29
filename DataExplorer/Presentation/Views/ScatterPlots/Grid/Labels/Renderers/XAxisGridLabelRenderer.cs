using System.Collections.Generic;
using System.Windows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Labels.Renderers
{
    public class XAxisGridLabelRenderer : IXAxisGridLabelRenderer
    {
        private const double MarginHeight = 15d;

        private readonly IValueScaler _valueScaler;

        public XAxisGridLabelRenderer(IValueScaler valueScaler)
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
            var scaledPosition = _valueScaler.Scale(axisGridLine.Position, viewExtent.Left, viewExtent.Width, 0d, controlSize.Width);

            var canvasLine = new CanvasLabel()
            {
                Text = axisGridLine.LabelName,
                X = scaledPosition,
                Y = controlSize.Height - MarginHeight
            };

            return canvasLine;
        }
    }
}
