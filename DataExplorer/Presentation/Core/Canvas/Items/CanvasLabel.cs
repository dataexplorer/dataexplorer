using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace DataExplorer.Presentation.Core.Canvas.Items
{
    public class CanvasLabel : ICanvasItem
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

                double x = this.X - (text.Width / 2);
                double y = this.Y - text.Height - 10;

                context.DrawText(text, new Point(x, y));
            }

            return visual;
        }
    }
}
