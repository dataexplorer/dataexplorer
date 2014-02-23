using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Titles.Renderers
{
    public interface IAxisTitleRenderer
    {
        CanvasLabel RenderXAxisTitle(Size controlSize, string text);

        CanvasLabel RenderYAxisTitle(Size controlSize, string text);
    }
}
