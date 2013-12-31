using System.Windows;

namespace DataExplorer.Application.Views.ScatterPlots.Commands
{
    public interface ISetViewExtentCommand
    {
        void SetViewExtent(Rect viewExtent);
    }
}