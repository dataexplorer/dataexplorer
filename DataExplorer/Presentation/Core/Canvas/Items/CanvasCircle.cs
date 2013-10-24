using System.Windows;
using System.Windows.Media;

namespace DataExplorer.Presentation.Core.Canvas.Items
{
    public class CanvasCircle : ICanvasItem
    {
        public double X;
        
        public double Y;
        
        public double Radius;

        public Visual Draw()
        {
            var visual = new DrawingVisual();
            
            // TODO: Move default brush and pen to static fiels and intialize / freeze in static constructer
            var brush = new SolidColorBrush(Colors.LightBlue);
            brush.Freeze();

            var pen = new Pen(Brushes.Black, 1);
            pen.Freeze();

            using (var context = visual.RenderOpen())
            {
                context.DrawEllipse(brush, pen, new Point(this.X, this.Y), this.Radius, this.Radius);
            }

            return visual;
        }
    }
}
