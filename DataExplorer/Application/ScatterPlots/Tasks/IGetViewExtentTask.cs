using System.Windows;

namespace DataExplorer.Application.ScatterPlots.Tasks
{
    public interface IGetViewExtentTask
    {
        Rect GetViewExtent();
    }
}