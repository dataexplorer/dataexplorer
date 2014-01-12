using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.Scalers
{
    [TestFixture]
    public class ScaleComputerTests
    {
        private ScaleComputer _renderer;

        [SetUp]
        public void SetUp()
        {
            _renderer = new ScaleComputer();
        }

        [Test]
        public void TestComputeScaleShouldReturnActualWidthOverViewWidthIfActualWidthIsGreaterThanHeight()
        {
            var actualExtent = new Rect(0, 0, 1, 0);
            var viewExtent = new Rect(0, 0, 2, 0);
            var scale = _renderer.ComputeScale(actualExtent.Size, viewExtent);
            Assert.That(scale, Is.EqualTo(0.5));
        }

        [Test]
        public void TestComputeScaleShouldReturnActualHeightOverViewHeightIfActualHeightIsGreaterThanWidth()
        {
            var actualExtent = new Rect(0, 0, 0, 1);
            var viewExtent = new Rect(0, 0, 0, 4);
            var scale = _renderer.ComputeScale(actualExtent.Size, viewExtent);
            Assert.That(scale, Is.EqualTo(0.25));
        }
    }
}
