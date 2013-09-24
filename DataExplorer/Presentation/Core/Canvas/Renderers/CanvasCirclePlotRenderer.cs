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
    public class CanvasCirclePlotRenderer : ICanvasCirclePlotRenderer
    {
        public Visual DrawCircle(Circle circle, SolidColorBrush brush, Pen pen)
        {
            var visual = new DrawingVisual();

            using (var context = visual.RenderOpen())
            {
                context.DrawEllipse(brush, pen, new Point(circle.X, circle.Y), circle.Radius, circle.Radius);
            }

            return visual;
        }
    }
}
