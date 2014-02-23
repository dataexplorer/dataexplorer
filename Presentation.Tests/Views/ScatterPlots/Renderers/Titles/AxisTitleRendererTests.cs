using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Titles.Renderers;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots.Renderers.Titles
{
    [TestFixture]
    public class AxisTitleRendererTests
    {
        private AxisTitleRenderer _renderer;
        private Mock<IXAxisTitleRenderer> _mockXRenderer;
        private Mock<IYAxisTitleRenderer> _mockYRenderer;
        private Size _controlSize;
        private CanvasLabel _label;

        [SetUp]
        public void Setup()
        {
            _controlSize = new Size();
            _label = new CanvasLabel();

            _mockXRenderer = new Mock<IXAxisTitleRenderer>();
            _mockYRenderer = new Mock<IYAxisTitleRenderer>();

            _renderer = new AxisTitleRenderer(
                _mockXRenderer.Object,
                _mockYRenderer.Object);
        }

        [Test]
        public void TestRenderXAxisTitleShouldReturnTitle()
        {
            _mockXRenderer.Setup(p => p.Render(_controlSize, "test"))
                .Returns(_label);

            var result = _renderer.RenderXAxisTitle(_controlSize, "test");

            Assert.That(result, Is.EqualTo(_label));
        }

        [Test]
        public void TestRenderYAxisTitleShouldReturnTitle()
        {
            _mockYRenderer.Setup(p => p.Render(_controlSize, "test"))
                .Returns(_label);

            var result = _renderer.RenderYAxisTitle(_controlSize, "test");

            Assert.That(result, Is.EqualTo(_label));
        }
    }
}
