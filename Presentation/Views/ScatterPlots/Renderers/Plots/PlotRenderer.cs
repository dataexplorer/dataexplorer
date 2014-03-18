using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Factories;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Core.Geometry;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;

namespace DataExplorer.Presentation.Views.ScatterPlots.Renderers.Plots
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

            var items = new List<CanvasItem>();

            foreach (var plotDto in plots)
            {
                var extent = _calculator.CalculatePlotExtent(controlSize, viewExtent, scale, new Point(plotDto.X, plotDto.Y), plotDto.Size);

                var plotItem = RenderPlot(extent, plotDto);

                items.Add(plotItem);

                if (string.IsNullOrEmpty(plotDto.Label))
                    continue;

                var labelItem = RenderLabel(extent, plotDto);

                items.Add(labelItem);
            }

            return items;
        }

        private CanvasItem RenderPlot(Rect extent, PlotDto plot)
        {
            var color = Color.FromRgb(plot.Color.Red, plot.Color.Green, plot.Color.Blue);

            var plotItem = plot.Image != null 
                ? (CanvasItem) _factory.CreateImage(plot.Id, extent, plot.Image)
                : (CanvasItem) _factory.CreateCircle(plot.Id, extent, color);

            return plotItem;
        }
        
        private CanvasItem RenderLabel(Rect plotExtent, PlotDto plotDto)
        {
            var origin = _calculator.CalcluateLabelOrigin(plotExtent);

            var label = _factory.CreateLabel(plotDto.Id, origin, plotDto.Label);

            return label;
        }
    }
}
