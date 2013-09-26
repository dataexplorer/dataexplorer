using System.Windows;

namespace DataExplorer.Application.ScatterPlots.Tasks
{
    public interface ISetViewExtentTask
    {
        void SetViewExtent(Rect viewExtent);
    }
}