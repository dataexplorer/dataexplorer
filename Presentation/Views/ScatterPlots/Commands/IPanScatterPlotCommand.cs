using System.Windows;

namespace DataExplorer.Presentation.Views.ScatterPlots.Commands
{
    public interface IPanScatterPlotCommand
    {
        void Execute(Vector vector, Size controlSize);
    }
}