using System.Windows;
using System.Windows.Media;

namespace DataExplorer.Presentation.Core.Canvas.Items
{
    public class CanvasBackground : ICanvasItem
    {
        public double Width;
        
        public double Height;

        public Visual Draw()
        {
            var background = new DrawingVisual();
            
            using (var context = background.RenderOpen())
            {
                var rectangle = new Rect(0, 0, this.Width, this.Height);
                context.DrawRectangle(Brushes.White, null, rectangle);
            }

            return background;
        }
    }
}
