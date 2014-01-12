using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DataExplorer.Presentation.Core.Canvas.Items
{
    public class CanvasLine : CanvasItem
    {
        public double X1 { get; set; }

        public double Y1 { get; set; }

        public double X2 { get; set; }
        
        public double Y2 { get; set; }

        public override VisualItem Draw()
        {
            var pen = new Pen(Brushes.LightGray, 1);

            var visual = new VisualItem();
            
            using (var context = visual.RenderOpen())
            {
                context.DrawLine(pen, new Point(X1, Y1), new Point(X2, Y2));
            }

            return visual;
        }
    }
}
