using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Titles.Queries
{
    public interface IGetXAxisTitleQuery
    {
        CanvasLabel Execute(Size controlSize);
    }
}
