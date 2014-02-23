using System;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Renderers.Titles
{
    public interface IAxisTitleRenderer
    {
        CanvasLabel RenderXAxisTitle(Size controlSize, string text);

        CanvasLabel RenderYAxisTitle(Size controlSize, string text);
    }
}
