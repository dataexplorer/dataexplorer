using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Titles
{
    public interface ITitleQueries
    {
        CanvasLabel GetXAxisTitle(Size controlSize);
        CanvasLabel GetYAxisTitle(Size controlSize);
    }
}