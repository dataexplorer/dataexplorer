using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Titles.Renderers
{
    public class AxisTitleRenderer : IAxisTitleRenderer
    {
        private readonly IXAxisTitleRenderer _xAxisTitleRenderer;
        private readonly IYAxisTitleRenderer _yAxisTitleRenderer;

        public AxisTitleRenderer(
            IXAxisTitleRenderer xAxisTitleRenderer, 
            IYAxisTitleRenderer yAxisTitleRenderer)
        {
            _xAxisTitleRenderer = xAxisTitleRenderer;
            _yAxisTitleRenderer = yAxisTitleRenderer;
        }

        public CanvasLabel RenderXAxisTitle(Size controlSize, string text)
        {
            return _xAxisTitleRenderer.Render(controlSize, text);
        }

        public CanvasLabel RenderYAxisTitle(Size controlSize, string text)
        {
            return _yAxisTitleRenderer.Render(controlSize, text);
        }
    }
}
