﻿using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Renderers.Titles;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots.Renderers.Titles
{
    [TestFixture]
    public class XAxisTitleRendererTests
    {
        private XAxisTitleRenderer _renderer;
        private Size _controlSize;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size(100d, 100d);

            _renderer = new XAxisTitleRenderer();
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
            Assert.That(result.Y, Is.EqualTo(100d));
        }

        [Test]
        public void TestRenderReturnsLabelWithText()
        {
            var result = _renderer.Render(_controlSize, "Test");
            Assert.That(result.Text, Is.EqualTo("Test"));
        }
    }
}
