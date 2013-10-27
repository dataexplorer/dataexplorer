using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisTitles.Renderers
{
    public interface IScatterPlotXAxisTitleRenderer
    {
        CanvasLabel Render(Size controlSize, string text);
    }
}