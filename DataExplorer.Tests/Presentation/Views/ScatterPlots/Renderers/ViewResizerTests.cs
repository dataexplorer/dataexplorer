using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Views.ScatterPlots.Renderers;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.Renderers
{
    [TestFixture]
    public class ViewResizerTests
    {
        private ViewResizer _resizer;

        [SetUp]
        public void SetUp()
        {
            _resizer = new ViewResizer();
        }

        [Test]
        public void TestResizeViewShouldHandleAllZeros()
        {
            var controlSize = new Size(0, 0);
            var viewExtent = new Rect(0, 0, 0, 0);
            var newExtent = new Rect(0, 0, 0, 0);
            var result = _resizer.ResizeView(controlSize, viewExtent);
            Assert.That(result, Is.EqualTo(newExtent));
        }

        [Test]
        public void TestResizeViewShouldScaleViewWidthWhenControlWidthIsReduced()
        {
            var controlSize = new Size(5, 10);
            var viewExtent = new Rect(0, 0, 10, 10);
            var newExtent = new Rect(0, -5, 10, 20);
            var result = _resizer.ResizeView(controlSize, viewExtent);
            Assert.That(result, Is.EqualTo(newExtent));
        }

        [Test]
        public void TestResizeViewShouldScaleViewHeightWhenControlHeightIsReduced()
        {
            var controlSize = new Size(10, 5);
            var viewExtent = new Rect(0, 0, 10, 10);
            var newExtent = new Rect(-5, 0, 20, 10);
            var result = _resizer.ResizeView(controlSize, viewExtent);
            Assert.That(result, Is.EqualTo(newExtent));
        }

        [Test]
        public void TestResizeViewShouldNotScaleViewWidthWhenControlWidthIsExpanded()
        {
            var controlSize = new Size(20, 10);
            var viewExtent = new Rect(0, 0, 10, 10);
            var newExtent = new Rect(-5, 0, 20, 10);
            var result = _resizer.ResizeView(controlSize, viewExtent);
            Assert.That(result, Is.EqualTo(newExtent));
        }

        [Test]
        public void TestResizeViewShouldNotScaleViewHeightWhenControlHeightIsExpanded()
        {
            var controlSize = new Size(10, 20);
            var viewExtent = new Rect(0, 0, 10, 10);
            var newExtent = new Rect(0, -5, 10, 20);
            var result = _resizer.ResizeView(controlSize, viewExtent);
            Assert.That(result, Is.EqualTo(newExtent));
        }
    }
}
