using System.Windows;

namespace DataExplorer.Presentation.Views.ScatterPlots.Commands
{
    public interface IZoomOutScatterPlotCommand
    {
        void Execute(Point center, Size controlSize);
    }
}