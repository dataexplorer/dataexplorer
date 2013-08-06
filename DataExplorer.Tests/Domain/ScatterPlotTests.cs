using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Domain.ScatterPlot;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain
{
    [TestFixture]
    public class ScatterPlotTests
    {
        private ScatterPlot _scatterPlot;

        [SetUp]
        public void SetUp()
        {
            _scatterPlot = new ScatterPlot();
        }

        // TODO: Should I eliminate this duplication with DCI?

        [Test]
        public void TestGetSetViewExtentShouldGetSetViewExtent()
        {
            var viewExtent = new Rect();
            _scatterPlot.SetViewExtent(viewExtent);
            var result = _scatterPlot.GetViewExtent();
            Assert.That(result, Is.EqualTo(viewExtent));
        }

        [Test]
        public void TestGetSetPlotsShouldGetSetPlots()
        {
            var plots = new List<Plot>();
            _scatterPlot.SetPlots(plots);
            var result = _scatterPlot.GetPlots();
            Assert.That(result, Is.EqualTo(plots));
        }
    }
}
