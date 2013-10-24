using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Renderers
{
    public interface IScatterPlotXAxisLabelRenderer
    {
        CanvasXAxisLabel Render(Size controlSize, string text);
    }
}