using System.Windows;

namespace DataExplorer.Application.Views.ScatterPlots.Commands
{
    public interface IZoomOutCommand
    {
        void ZoomOut(Point center);
    }
}
