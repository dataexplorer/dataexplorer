using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Core.Geometry;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;

namespace DataExplorer.Presentation.Views.ScatterPlots.Plots.Renderers
{
    public class PlotRenderer : IPlotRenderer
    {
        private readonly IViewResizer _resizer;
        private readonly IScaleComputer _computer;
        private readonly IGeometryCalculator _calculator;
        private readonly IGeometryFactory _factory;

        public PlotRenderer(
            IViewResizer resizer,
            IScaleComputer computer,
            IGeometryCalculator calculator, 
            IGeometryFactory factory)
        {
            _resizer = resizer;
            _computer = computer;
            _calculator = calculator;
            _factory = factory;
        }

        public List<CanvasItem> RenderPlots(Size controlSize, Rect viewExtent, List<PlotDto> plots)
        {
            var resizedViewExtent = _resizer.ResizeView(controlSize, viewExtent);

            var scale = _computer.ComputeScale(controlSize, resizedViewExtent);

            return plots.Select(p => RenderPlot(controlSize, resizedViewExtent, scale, p)).ToList();
        }

        private CanvasItem RenderPlot(Size controlSize, Rect viewExtent, double scale, PlotDto plot)
        {
            var extent = _calculator.CalculateExtent(controlSize, viewExtent, scale, new Point(plot.X, plot.Y));

            var color = Color.FromRgb(plot.Color.Red, plot.Color.Green, plot.Color.Blue);

            var circle = _factory.CreateCircle(plot.Id, extent, color);

            return circle;
        }
    }
}
