using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using DataExplorer.Presentation.Core.Geometry;

namespace DataExplorer.Presentation.Core.Canvas
{
    public class CanvasRenderer : ICanvasRenderer
    {
        public List<Visual> DrawVisuals(List<Circle> plots)
        {
            return plots.Select(p => DrawCircle(p)).ToList();
        }

        public Visual DrawCircle(Circle circle)
        {
            var visual = new DrawingVisual();
            using (var context = visual.RenderOpen())
            {
                var brush = new SolidColorBrush(Colors.LightBlue);
                brush.Freeze();

                var pen = new Pen(Brushes.Black, 1);
                pen.Freeze();

                context.DrawEllipse(brush, pen, new Point(circle.X, circle.Y),  circle.Radius, circle.Radius);
            }
            return visual;
        }
    }
}
