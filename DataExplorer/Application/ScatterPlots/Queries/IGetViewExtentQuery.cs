using System.Windows;

namespace DataExplorer.Application.ScatterPlots.Queries
{
    public interface IGetViewExtentQuery
    {
        Rect GetViewExtent();
    }
}