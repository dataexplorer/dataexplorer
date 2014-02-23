using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Titles.Renderers
{
    public class XAxisTitleRenderer : IXAxisTitleRenderer
    {
        public CanvasLabel Render(Size controlSize, string text)
        {
            var label = new CanvasLabel();
            
            label.X = controlSize.Width / 2;

            label.Y = controlSize.Height + 5; 
            
            label.Text = text;

            return label;
        }
    }
}
