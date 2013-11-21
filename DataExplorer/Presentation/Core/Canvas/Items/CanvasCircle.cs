using System.Windows;
using System.Windows.Media;

namespace DataExplorer.Presentation.Core.Canvas.Items
{
    public class CanvasCircle : CanvasItem
    {
        public double X { get; set; }
        
        public double Y { get; set; }
        
        public double Radius { get; set; }

        public override VisualItem Draw()
        {
            var visual = new VisualItem();

            visual.Id = Id;

            // TODO: Move default brush and pen to static fiels and intialize / freeze in static constructer
            var brush = new SolidColorBrush(Colors.LightBlue);
            brush.Freeze();

            var unselectedPen = new Pen(Brushes.Black, 1);
            unselectedPen.Freeze();

            var selectedPen = new Pen(Brushes.Blue, 2);
            selectedPen.Freeze();

            var pen = IsSelected ? selectedPen : unselectedPen;

            using (var context = visual.RenderOpen())
            {
                context.DrawEllipse(brush, pen, new Point(this.X, this.Y), this.Radius, this.Radius);
            }

            return visual;
        }
    }
}
