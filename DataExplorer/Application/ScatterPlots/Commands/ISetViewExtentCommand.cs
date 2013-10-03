using System.Windows;

namespace DataExplorer.Application.ScatterPlots.Commands
{
    public interface ISetViewExtentCommand
    {
        void SetViewExtent(Rect viewExtent);
    }
}