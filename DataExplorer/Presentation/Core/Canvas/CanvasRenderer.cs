using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using DataExplorer.Presentation.Core.Canvas.Renderers;
using DataExplorer.Presentation.Core.Geometry;

namespace DataExplorer.Presentation.Core.Canvas
{
    public class CanvasRenderer : ICanvasRenderer
    {
        private readonly ICanvasBackgroundRenderer _backgroundRenderer;
        private readonly ICanvasPlotRenderer _plotRenderer;

        public CanvasRenderer(
            ICanvasBackgroundRenderer backgroundRenderer, 
            ICanvasPlotRenderer plotRenderer)
        {
            _backgroundRenderer = backgroundRenderer;
            _plotRenderer = plotRenderer;
        }

        public Visual DrawBackground(double width, double height)
        {
            return _backgroundRenderer.DrawBackground(width, height);
        }

        public IEnumerable<Visual> DrawPlots(List<Circle> plots)
        {
            return _plotRenderer.DrawPlots(plots);
        }
    }
}
