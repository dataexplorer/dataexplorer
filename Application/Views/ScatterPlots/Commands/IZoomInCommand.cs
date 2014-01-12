using System.Windows;

namespace DataExplorer.Application.Views.ScatterPlots.Commands
{
    public interface IZoomInCommand
    {
        void ZoomIn(Point center);
    }
}
