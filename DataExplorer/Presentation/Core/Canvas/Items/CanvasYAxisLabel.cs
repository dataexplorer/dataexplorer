using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace DataExplorer.Presentation.Core.Canvas.Items
{
    public class CanvasYAxisLabel : ICanvasItem
    {
        public double X;
        public double Y;
        public string Text;

        public Visual Draw()
        {
            var visual = new DrawingVisual();

            using (var context = visual.RenderOpen())
            {
                var text = new FormattedText(
                    this.Text,
                    CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Verdana"),
                    12,
                    Brushes.Black);

                double x = this.X;
                double y = this.Y - (text.Width / 2);

                visual.Transform = new RotateTransform(-90, x, y);

                context.DrawText(text, new Point(x, y));
            }

            return visual;
        }
    }
}
