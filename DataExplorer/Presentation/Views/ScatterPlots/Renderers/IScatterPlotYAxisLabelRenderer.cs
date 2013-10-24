using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Renderers
{
    public interface IScatterPlotYAxisLabelRenderer
    {
        CanvasYAxisLabel Render(Size controlSize, string text);
    }
}