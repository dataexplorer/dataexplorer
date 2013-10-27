using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.AxisTitles.Renderers;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.AxisTitles.Renderers
{
    [TestFixture]
    public class ScatterPlotXAxisLabelRendererTests
    {
        private ScatterPlotXAxisTitleRenderer _renderer;
        private Size _controlSize;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size(100d, 100d);

            _renderer = new ScatterPlotXAxisTitleRenderer();
        }

        [Test]
        public void TestRenderReturnsLabel()
        {
            var result = _renderer.Render(_controlSize, "Test");
            Assert.That(result, Is.TypeOf<CanvasLabel>());
        }

        [Test]
        public void TestRenderReturnsLabelWithXPositionAtMidpoint()
        {
            var result = _renderer.Render(_controlSize, "Test");
            Assert.That(result.X, Is.EqualTo(50d));
        }

        [Test]
        public void TestRenderReturnsLabelWithYPositionAtBaseline()
        {
            var result = _renderer.Render(_controlSize, "Test");
            Assert.That(result.Y, Is.EqualTo(105d));
        }

        [Test]
        public void TestRenderReturnsLabelWithText()
        {
            var result = _renderer.Render(_controlSize, "Test");
            Assert.That(result.Text, Is.EqualTo("Test"));
        }
    }
}
