using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Titles.Renderers
{
    public interface IXAxisTitleRenderer
    {
        CanvasLabel Render(Size controlSize, string text);
    }
}
