using System;
using System.Collections.Generic;
using System.Windows;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Renderers.Grid
{
    public class AxisGridRenderer : IAxisGridRenderer
    {
        private readonly IXAxisGridLineRenderer _xAxisGridLineRenderer;
        private readonly IYAxisGridLineRenderer _yAxisGridLineRenderer;
        private readonly IXAxisGridLabelRenderer _xAxisGridLabelRenderer;
        private readonly IYAxisGridLabelRenderer _yAxisGridLabelRenderer;

        public AxisGridRenderer(
            IXAxisGridLineRenderer xAxisGridLineRenderer,
            IYAxisGridLineRenderer yAxisGridLineRenderer,
            IXAxisGridLabelRenderer xAxisGridLabelRenderer,
            IYAxisGridLabelRenderer yAxisGridLabelRenderer)
        {
            _xAxisGridLineRenderer = xAxisGridLineRenderer;
            _yAxisGridLineRenderer = yAxisGridLineRenderer;
            _xAxisGridLabelRenderer = xAxisGridLabelRenderer;
            _yAxisGridLabelRenderer = yAxisGridLabelRenderer;
        }

        public IEnumerable<CanvasLine> RenderXAxisGridLines(IEnumerable<AxisGridLine> axisLines, Rect viewExtent, Size controlSize)
        {
            return _xAxisGridLineRenderer.Render(axisLines, viewExtent, controlSize);
        }

        public IEnumerable<CanvasLine> RenderYAxisGridLines(IEnumerable<AxisGridLine> axisLines, Rect viewExtent, Size controlSize)
        {
            return _yAxisGridLineRenderer.Render(axisLines, viewExtent, controlSize);
        }

        public IEnumerable<CanvasLabel> RenderXAxisGridLabels(IEnumerable<AxisGridLine> axisLines, Rect viewExtent, Size controlSize)
        {
            return _xAxisGridLabelRenderer.Render(axisLines, viewExtent, controlSize);
        }

        public IEnumerable<CanvasLabel> RenderYAxisGridLabels(IEnumerable<AxisGridLine> axisLines, Rect viewExtent, Size controlSize)
        {
            return _yAxisGridLabelRenderer.Render(axisLines, viewExtent, controlSize);
        }
    }
}
