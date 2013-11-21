using System.Windows;
using System.Windows.Media;

namespace DataExplorer.Presentation.Core.Canvas.Items
{
    public class CanvasBackground : CanvasItem
    {
        public double Width { get; set; }
        
        public double Height { get; set; }

        public override VisualItem Draw()
        {
            var background = new VisualItem();
            
            using (var context = background.RenderOpen())
            {
                var rectangle = new Rect(0, 0, this.Width, this.Height);
                context.DrawRectangle(Brushes.White, null, rectangle);
            }

            return background;
        }
    }
}
