using System.Windows;

namespace DataExplorer.Presentation.Views.ScatterPlots.Commands
{
    public interface IZoomInScatterPlotCommand
    {
        void Execute(Point center, Size controlSize);
    }
}