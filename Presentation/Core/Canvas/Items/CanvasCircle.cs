using System.Windows;
using System.Windows.Media;

namespace DataExplorer.Presentation.Core.Canvas.Items
{
    public class CanvasCircle : CanvasItem
    {
        public double X { get; set; }
        
        public double Y { get; set; }
        
        public double Radius { get; set; }

        public Color Color { get; set; }

        public override VisualItem Draw()
        {
            var visual = new VisualItem();

            visual.Id = Id;

            // TODO: Move default brush and pen to static fields and intialize / freeze in static constructer
            var brush = new SolidColorBrush(Color);
            brush.Freeze();

            var pen = GetPen();

            using (var context = visual.RenderOpen())
            {
                context.DrawEllipse(brush, pen, new Point(this.X, this.Y), this.Radius, this.Radius);
            }

            return visual;
        }
    }
}
