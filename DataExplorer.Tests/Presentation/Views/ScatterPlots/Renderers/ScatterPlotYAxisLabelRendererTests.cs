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
    public class ScatterPlotYAxisLabelRendererTests
    {
        private ScatterPlotYAxisLabelRenderer _renderer;
        private Size _controlSize;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size(100d, 100d);

            _renderer = new ScatterPlotYAxisLabelRenderer();
        }

        [Test]
        public void TestRenderReturnsLabel()
        {
            var result = _renderer.Render(_controlSize, "Test");
            Assert.That(result, Is.TypeOf<CanvasYAxisLabel>());
        }

        [Test]
        public void TestRenderReturnsLabelWithXPositionAtBaseline()
        {
            var result = _renderer.Render(_controlSize, "Test");
            Assert.That(result.X, Is.EqualTo(10d));
        }

        [Test]
        public void TestRenderReturnsLabelWithYPositionAtMidpoint()
        {
            var result = _renderer.Render(_controlSize, "Test");
            Assert.That(result.Y, Is.EqualTo(50d));
        }
        
        [Test]
        public void TestRenderReturnsLabelWithText()
        {
            var result = _renderer.Render(_controlSize, "Test");
            Assert.That(result.Text, Is.EqualTo("Test"));
        }
    }
}
