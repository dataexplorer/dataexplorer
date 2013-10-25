using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DataExplorer.Presentation.Core.Canvas.Items
{
    public class CanvasLine : ICanvasItem
    {
        public double X1;
        public double Y1;
        public double X2;
        public double Y2;
        
        public Visual Draw()
        {
            var pen = new Pen(Brushes.LightGray, 1);

            var visual = new DrawingVisual();
            
            using (var context = visual.RenderOpen())
            {
                context.DrawLine(pen, new Point(X1, Y1), new Point(X2, Y2));
            }

            return visual;
        }
    }
}
