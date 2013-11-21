using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DataExplorer.Presentation.Core.Canvas.Items
{
    public class CanvasLabel : CanvasItem
    {
        public double X { get; set; }

        public double Y { get; set; }
        
        public string Text { get; set; }
        
        public bool IsRotated { get; set; }

        public override VisualItem Draw()
        {
            var visual = new VisualItem();

            using (var context = visual.RenderOpen())
            {
                var text = new FormattedText(
                    this.Text,
                    CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Verdana"),
                    12,
                    Brushes.Black);

                double x = IsRotated 
                    ? this.X 
                    : this.X - (text.Width / 2);

                double y = IsRotated
                    ? this.Y + (text.Width / 2)
                    : this.Y - text.Height - 10;

                if (IsRotated)
                    visual.Transform = new RotateTransform(-90, x, y);

                context.DrawText(text, new Point(x, y));
            }

            return visual;
        }
    }
}
