using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Presentation.Core.Geometry;

namespace DataExplorer.Presentation.Views.ScatterPlots
{
    public class ScatterPlotViewRenderer : IScatterPlotViewRenderer
    {
        private readonly IGeometryCalculator _calculator;
        private readonly IGeometryFactory _factory;

        public ScatterPlotViewRenderer(
            IGeometryCalculator calculator,
            IGeometryFactory factory)
        {
            _calculator = calculator;
            _factory = factory;
        }

        public List<Circle> RenderPlots(Size controlSize, Rect viewExtent, List<PlotDto> plots)
        {
            var resizedViewExtent = ResizeView(controlSize, viewExtent);

            var scale = ComputeScale(controlSize, resizedViewExtent);

            return plots.Select(p => RenderPlot(controlSize, resizedViewExtent, scale, p)).ToList();
        }

        public double ComputeScale(Size controlSize, Rect viewExtent)
        {
            return (controlSize.Width > controlSize.Height)
                ? controlSize.Width / viewExtent.Width
                : controlSize.Height / viewExtent.Height;
        }
        
        private Circle RenderPlot(Size controlSize, Rect viewExtent, double scale, PlotDto plot)
        {
            var extent = _calculator.CalculateExtent(controlSize, viewExtent, scale, new Point(plot.X, plot.Y));

            var circle = _factory.CreateCircle(extent);

            return circle;
        }

        public Rect ResizeView(Size controlSize, Rect viewExtent)
        {
            var aspectRatio = controlSize.Width / controlSize.Height;

            var width = (aspectRatio > 1)
                ? viewExtent.Height * aspectRatio
                : viewExtent.Width;

            var height = (aspectRatio < 1)
                ? viewExtent.Width * (1 / aspectRatio)
                : viewExtent.Height;

            var left = viewExtent.Left - (width - viewExtent.Width) / 2;

            var top = viewExtent.Top - (height - viewExtent.Height) / 2;

            return new Rect(left, top, width, height);
        }
    }
}
