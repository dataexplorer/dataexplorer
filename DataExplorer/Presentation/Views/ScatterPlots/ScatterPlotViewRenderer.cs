using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Renderers;

namespace DataExplorer.Presentation.Views.ScatterPlots
{
    public class ScatterPlotViewRenderer : IScatterPlotViewRenderer
    {
        private readonly IScatterPlotPlotRenderer _plotRenderer;
        private readonly IScatterPlotXAxisLabelRenderer _xAxisLabelRenderer;
        private readonly IScatterPlotYAxisLabelRenderer _yAxisLabelRenderer;

        public ScatterPlotViewRenderer(
            IScatterPlotPlotRenderer plotRenderer,
            IScatterPlotXAxisLabelRenderer xAxisLabelRenderer, 
            IScatterPlotYAxisLabelRenderer yAxisLabelRenderer)
        {
            _plotRenderer = plotRenderer;
            _xAxisLabelRenderer = xAxisLabelRenderer;
            _yAxisLabelRenderer = yAxisLabelRenderer;
        }

        public List<CanvasCircle> RenderPlots(Size controlSize, Rect viewExtent, List<PlotDto> plots)
        {
            return _plotRenderer.RenderPlots(controlSize, viewExtent, plots);
        }

        public CanvasXAxisLabel RenderXAxisLabel(Size controlSize, string labelText)
        {
            return _xAxisLabelRenderer.Render(controlSize, labelText);
        }

        public CanvasYAxisLabel RenderYAxisLabel(Size controlSize, string labelText)
        {
            return _yAxisLabelRenderer.Render(controlSize, labelText);
        }
    }
}
