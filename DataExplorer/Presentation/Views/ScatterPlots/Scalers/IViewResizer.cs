using System.Windows;

namespace DataExplorer.Presentation.Views.ScatterPlots.Renderers
{
    public interface IViewResizer
    {
        Rect ResizeView(Size controlSize, Rect viewExtent);
    }
}