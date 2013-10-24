using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots;
using DataExplorer.Presentation.Views.ScatterPlots.Renderers;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotViewRendererTests
    {
        private ScatterPlotViewRenderer _renderer;
        private Mock<IScatterPlotPlotRenderer> _mockPlotRenderer;
        private Mock<IScatterPlotXAxisLabelRenderer> _mockXAxisRenderer;
        private Mock<IScatterPlotYAxisLabelRenderer> _mockYAxisRenderer;
        private Size _controlSize;
        private Rect _viewExtent;
        private List<PlotDto> _plots;
        private List<CanvasCircle> _circles;
        private CanvasCircle _circle;
        private CanvasXAxisLabel _xAxisLabel;
        private CanvasYAxisLabel _yAxisLabel;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size();
            _viewExtent = new Rect();
            _plots = new List<PlotDto>();
            _circle = new CanvasCircle();
            _circles = new List<CanvasCircle> { _circle };
            _xAxisLabel = new CanvasXAxisLabel();
            _yAxisLabel = new CanvasYAxisLabel();

            _mockPlotRenderer = new Mock<IScatterPlotPlotRenderer>();
            _mockPlotRenderer.Setup(p => p.RenderPlots(_controlSize, _viewExtent, _plots)).Returns(_circles);

            _mockXAxisRenderer = new Mock<IScatterPlotXAxisLabelRenderer>();
            _mockXAxisRenderer.Setup(p => p.Render(_controlSize, "Test")).Returns(_xAxisLabel);

            _mockYAxisRenderer = new Mock<IScatterPlotYAxisLabelRenderer>();
            _mockYAxisRenderer.Setup(p => p.Render(_controlSize, "Test")).Returns(_yAxisLabel);

            _renderer = new ScatterPlotViewRenderer(
                _mockPlotRenderer.Object,
                _mockXAxisRenderer.Object,
                _mockYAxisRenderer.Object);
        }
        
        [Test]
        public void TestRenderPlotsShouldReturnRenderedPlots()
        {
            var results = _renderer.RenderPlots(_controlSize, _viewExtent, _plots);
            Assert.That(results.Single(), Is.EqualTo(_circle));
        }

        [Test]
        public void TestRenderXAxisLabelShouldReturnXAxisLabel()
        {
            var result = _renderer.RenderXAxisLabel(_controlSize, "Test");
            Assert.That(result, Is.EqualTo(_xAxisLabel));
        }

        [Test]
        public void TestRenderYAxisLabelShouldReturnYAxisLabel()
        {
            var result = _renderer.RenderYAxisLabel(_controlSize, "Test");
            Assert.That(result, Is.EqualTo(_yAxisLabel));
        }
    }
}
