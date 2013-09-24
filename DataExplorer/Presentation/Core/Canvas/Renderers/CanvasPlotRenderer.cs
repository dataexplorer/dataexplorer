using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using DataExplorer.Presentation.Core.Geometry;

namespace DataExplorer.Presentation.Core.Canvas.Renderers
{
    public class CanvasPlotRenderer : ICanvasPlotRenderer
    {
        private readonly ICanvasCirclePlotRenderer _circleRenderer;

        public CanvasPlotRenderer(ICanvasCirclePlotRenderer circleRenderer)
        {
            _circleRenderer = circleRenderer;
        }

        public IEnumerable<Visual> DrawPlots(List<Circle> plots)
        {
            var brush = new SolidColorBrush(Colors.LightBlue);
            brush.Freeze();

            var pen = new Pen(Brushes.Black, 1);
            pen.Freeze();

            return plots.Select(plot => _circleRenderer.DrawCircle(plot, brush, pen));
        }
    }
}
