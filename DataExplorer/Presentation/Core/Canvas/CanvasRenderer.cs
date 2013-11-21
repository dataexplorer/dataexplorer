using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Core.Canvas
{
    public class CanvasRenderer : ICanvasRenderer
    {
        public Visual DrawBackground(double width, double height)
        {
            var background = new CanvasBackground();
            background.Width = width;
            background.Height = height;
            return background.Draw();
        }

        public IEnumerable<Visual> DrawItems(List<CanvasItem> items)
        {
            return items.Select(p => p.Draw());
        }
    }
}
