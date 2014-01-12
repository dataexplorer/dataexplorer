using System.Windows;

namespace DataExplorer.Presentation.Views.ScatterPlots.Commands
{
    public interface IResizeScatterPlotViewExtentCommand
    {
        void Execute(Size controlSize);
    }
}