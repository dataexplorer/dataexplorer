using System.Windows;

namespace DataExplorer.Presentation.Views.ScatterPlots.Scalers
{
    public interface IViewResizer
    {
        Rect ResizeView(Size controlSize, Rect viewExtent);
    }
}