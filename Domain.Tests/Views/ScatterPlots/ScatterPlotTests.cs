using System.Collections.Generic;
using System.Windows;
using DataExplorer.Domain.Core.Events;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots.Events;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Views.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotTests
    {
        private ScatterPlot _scatterPlot;

        [SetUp]
        public void SetUp()
        {
            _scatterPlot = new ScatterPlotBuilder().Build();
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

        [Test]
        public void TestSetPlotsShouldRaiseScatterPlotChangedEvent()
        {
            var plots = new List<Plot>();
            var wasScatterPlotChanged = false;
            DomainEvents.Register<ScatterPlotChangedEvent>(p => { wasScatterPlotChanged = true; });
            _scatterPlot.SetPlots(plots);
            Assert.That(wasScatterPlotChanged, Is.True);
            DomainEvents.ClearHandlers();
        }
    }
}
