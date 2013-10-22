using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using DataExplorer.Presentation.Core.Canvas;
using DataExplorer.Presentation.Core.Canvas.Items;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Core.Canvas
{
    [TestFixture]
    public class CanvasRendererTests
    {
        private CanvasRenderer _canvasRenderer;
        private List<ICanvasItem> _plots;
        private CanvasCircle _plot;

        [SetUp]
        public void SetUp()
        {
            _plot = new CanvasCircle();
            _plots = new List<ICanvasItem> { _plot };
            _canvasRenderer = new CanvasRenderer();
        }

        [Test]
        public void TestDrawBackgroundShouldDrawBackground()
        {
            var result = _canvasRenderer.DrawBackground(1d, 2d);
            Assert.That(result, Is.TypeOf<DrawingVisual>());
        }

        [Test]
        public void TestDrawPlotsShouldDrawPlots()
        {
            var results = _canvasRenderer.DrawItems(_plots);
            Assert.That(results.Single(), Is.TypeOf<DrawingVisual>());
        }
    }
}
