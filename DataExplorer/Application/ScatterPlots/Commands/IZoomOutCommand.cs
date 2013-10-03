using System.Windows;

namespace DataExplorer.Application.ScatterPlots.Commands
{
    public interface IZoomOutCommand
    {
        void ZoomOut(Point center);
    }
}
