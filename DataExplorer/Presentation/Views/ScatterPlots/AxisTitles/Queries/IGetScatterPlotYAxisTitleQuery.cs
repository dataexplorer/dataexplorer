using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisTitles.Queries
{
    public interface IGetScatterPlotYAxisTitleQuery
    {
        ICanvasItem Execute(Size controlSize);
    }
}
