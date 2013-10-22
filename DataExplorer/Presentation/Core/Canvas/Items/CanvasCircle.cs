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
            
            var brush = new SolidColorBrush(Colors.LightBlue);

            var pen = new Pen(Brushes.Black, 1);
            
            using (var context = visual.RenderOpen())
            {
                context.DrawEllipse(brush, pen, new Point(this.X, this.Y), this.Radius, this.Radius);
            }

            return visual;
        }
    }
}
