using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Renderers.Titles
{
    public interface IYAxisTitleRenderer
    {
        CanvasLabel Render(Size controlSize, string text);
    }
}