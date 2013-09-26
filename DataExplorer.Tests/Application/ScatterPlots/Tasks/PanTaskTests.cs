using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.ScatterPlots.Tasks;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.ScatterPlots.Tasks
{
    [TestFixture]
    public class PanTaskTests
    {
        private PanTask _task;
        private Mock<IViewRepository> _mockRepository;
        private ScatterPlot _scatterPlot;
        private Rect _viewExtent;
        private Vector _vector;

        [SetUp]
        public void SetUp()
        {
            _vector = new Vector(0.25, 0.5);
            _viewExtent = new Rect(0, 0, 1, 1);
            _scatterPlot = new ScatterPlot(_viewExtent, null, null);
            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>()).Returns(_scatterPlot);
            _task = new PanTask(_mockRepository.Object);
        }

        [Test]
        public void TestPanShouldPan()
        {
            _task.Pan(_vector);
            var newViewExtent = _scatterPlot.GetViewExtent();
            Assert.That(newViewExtent.X, Is.EqualTo(0.25));
            Assert.That(newViewExtent.Y, Is.EqualTo(0.5));
        }

        [Test]
        public void TestPanShouldRaiseScatterPlotChangedEvent()
        {
            var wasRaised = false;
            DomainEvents.Register<ScatterPlotChangedEvent>(p => { wasRaised = true; });
            _task.Pan(_vector);
            Assert.That(wasRaised, Is.True);
            DomainEvents.ClearHandlers();
        }
    }
}
