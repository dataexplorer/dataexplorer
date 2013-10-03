using System.Windows;

namespace DataExplorer.Application.ScatterPlots.Commands
{
    public interface IZoomInCommand
    {
        void ZoomIn(Point center);
    }
}
