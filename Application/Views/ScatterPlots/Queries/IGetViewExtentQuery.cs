using System.Windows;

namespace DataExplorer.Application.Views.ScatterPlots.Queries
{
    public interface IGetViewExtentQuery
    {
        Rect GetViewExtent();
    }
}