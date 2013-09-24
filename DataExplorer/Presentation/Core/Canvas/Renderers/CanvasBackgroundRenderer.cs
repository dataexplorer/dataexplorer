using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DataExplorer.Presentation.Core.Canvas.Renderers
{
    public class CanvasBackgroundRenderer : ICanvasBackgroundRenderer
    {
        public Visual DrawBackground(double width, double height)
        {
            var background = new DrawingVisual();
            
            using (var context = background.RenderOpen())
            {
                var rectangle = new Rect(0, 0, width, height);
                context.DrawRectangle(Brushes.White, null, rectangle);
            }

            return background;
        }
    }
}
