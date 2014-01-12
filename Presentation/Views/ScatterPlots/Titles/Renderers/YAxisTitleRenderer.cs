using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Titles.Renderers
{
    public class YAxisTitleRenderer : IYAxisTitleRenderer
    {
        public CanvasLabel Render(Size controlSize, string text)
        {
            var label = new CanvasLabel();
            
            label.X = 10;

            label.Y = controlSize.Height / 2;

            label.Text = text;

            label.IsRotated = true;

            return label;
        }
    }
}
