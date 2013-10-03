using System.Windows;

namespace DataExplorer.Application.ScatterPlots.Tasks
{
    public interface ISetViewExtentCommand
    {
        void SetViewExtent(Rect viewExtent);
    }
}