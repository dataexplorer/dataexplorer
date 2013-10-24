using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Renderers;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.Renderers
{
    [TestFixture]
    public class ScatterPlotXAxisLabelRendererTests
    {
        private ScatterPlotXAxisLabelRenderer _renderer;
        private Size _controlSize;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size(100d, 100d);

            _renderer = new ScatterPlotXAxisLabelRenderer();
        }

        [Test]
        public void TestRenderReturnsLabel()
        {
            var result = _renderer.Render(_controlSize, "Test");
            Assert.That(result, Is.TypeOf<CanvasXAxisLabel>());
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
            Assert.That(result.Y, Is.EqualTo(90d));
        }

        [Test]
        public void TestRenderReturnsLabelWithText()
        {
            var result = _renderer.Render(_controlSize, "Test");
            Assert.That(result.Text, Is.EqualTo("Test"));
        }
    }
}
