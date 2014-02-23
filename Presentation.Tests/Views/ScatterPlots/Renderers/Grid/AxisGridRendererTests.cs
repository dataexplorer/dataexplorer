using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Grid.Labels.Renderers;
using DataExplorer.Presentation.Views.ScatterPlots.Grid.Lines.Renderers;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots.Grid
{
    [TestFixture]
    public class AxisGridRendererTests
    {
        private AxisGridRenderer _renderer;
        private Mock<IXAxisGridLineRenderer> _mockXLineRenderer;
        private Mock<IYAxisGridLineRenderer> _mockYLineRenderer;
        private Mock<IXAxisGridLabelRenderer> _mockXLabelRenderer;
        private Mock<IYAxisGridLabelRenderer> _mockYLabelRenderer;
        private List<AxisGridLine> _gridLines;
        private Rect _viewExtent;
        private Size _controlSize;
        private CanvasLine _line;
        private CanvasLabel _label;

        [SetUp]
        public void SetUp()
        {
            _gridLines = new List<AxisGridLine>();
            _viewExtent = new Rect();
            _controlSize = new Size();
            _line = new CanvasLine();
            _label = new CanvasLabel();

            _mockXLineRenderer = new Mock<IXAxisGridLineRenderer>();
            _mockYLineRenderer = new Mock<IYAxisGridLineRenderer>();
            _mockXLabelRenderer = new Mock<IXAxisGridLabelRenderer>();
            _mockYLabelRenderer = new Mock<IYAxisGridLabelRenderer>();
            
            _renderer = new AxisGridRenderer(
                _mockXLineRenderer.Object,
                _mockYLineRenderer.Object,
                _mockXLabelRenderer.Object,
                _mockYLabelRenderer.Object);
        }

        [Test]
        public void TestRenderXAxisGridLinesShouldRenderLines()
        {
            _mockXLineRenderer.Setup(p => p.Render(_gridLines, _viewExtent, _controlSize))
                .Returns(new List<CanvasLine> { _line });

            var results = _renderer.RenderXAxisGridLines(_gridLines, _viewExtent, _controlSize);

            Assert.That(results.Single(), Is.EqualTo(_line));
        }

        [Test]
        public void TestRenderYAxisGridLinesShouldRenderLines()
        {
            _mockYLineRenderer.Setup(p => p.Render(_gridLines, _viewExtent, _controlSize))
                .Returns(new List<CanvasLine> { _line });

            var results = _renderer.RenderYAxisGridLines(_gridLines, _viewExtent, _controlSize);

            Assert.That(results.Single(), Is.EqualTo(_line));
        }

        [Test]
        public void TestRenderXAxisGridLabelsShouldRenderLabels()
        {
            _mockXLabelRenderer.Setup(p => p.Render(_gridLines, _viewExtent, _controlSize))
                .Returns(new List<CanvasLabel> { _label });

            var results = _renderer.RenderXAxisGridLabels(_gridLines, _viewExtent, _controlSize);

            Assert.That(results.Single(), Is.EqualTo(_label));
        }

        [Test]
        public void TestRenderYAxisGridLabelShouldRenderLabels()
        {
            _mockYLabelRenderer.Setup(p => p.Render(_gridLines, _viewExtent, _controlSize))
                .Returns(new List<CanvasLabel> { _label });

            var results = _renderer.RenderYAxisGridLabels(_gridLines, _viewExtent, _controlSize);

            Assert.That(results.Single(), Is.EqualTo(_label));
        }
    }
}
