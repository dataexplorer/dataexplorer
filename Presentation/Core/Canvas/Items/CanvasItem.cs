using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DataExplorer.Presentation.Core.Canvas.Items
{
    public abstract class CanvasItem
    {
        public int? Id { get; set; }

        public bool IsSelected { get; set; }

        public abstract VisualItem Draw();

        protected Brush GetBrush(Color color)
        {
            var brush = new SolidColorBrush(color);
            
            brush.Freeze();
            
            return brush;
        }

        protected Pen GetPen()
        {
            return IsSelected
                ? GetPen(Brushes.Blue, 2)
                : GetPen(Brushes.Black, 1);
        }

        private Pen GetPen(Brush color, double thickness)
        {
            var pen = new Pen(color, thickness);

            pen.Freeze();
            
            return pen;
        }
    }
}
