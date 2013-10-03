using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.ScatterPlots.Commands;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.ScatterPlots.Commands
{
    [TestFixture]
    public class ZoomToFullExtentCommandTests
    {
        private const double Tolerance = 0.000001;

        private ZoomToFullExtentCommand _command;
        private Mock<IViewRepository> _mockRepository;
        private ScatterPlot _scatterPlot;

        [SetUp]
        public void SetUp()
        {
            _scatterPlot = new ScatterPlot();
            
            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>()).Returns(_scatterPlot);
            
            _command = new ZoomToFullExtentCommand(_mockRepository.Object);
        }

        [Test]
        public void TestExecuteShouldZoomToFullExtentIfViewIsSquare()
        {
            var squareViewExtent = new Rect(0d, 0d, 1d, 1d);
            _scatterPlot.SetViewExtent(squareViewExtent);
            _command.Execute();
            var viewExtent = _scatterPlot.GetViewExtent();
            Assert.That(viewExtent.X, Is.EqualTo(-0.1d).Within(Tolerance));
            Assert.That(viewExtent.Y, Is.EqualTo(-0.1d).Within(Tolerance));
            Assert.That(viewExtent.Width, Is.EqualTo(1.2d).Within(Tolerance));
            Assert.That(viewExtent.Height, Is.EqualTo(1.2d).Within(Tolerance));
        }

        [Test]
        public void TestExecuteShouldZoomToFullExtentIfViewIsWide()
        {
            var wideViewExtent = new Rect(0d, 0d, 2d, 1d);
            _scatterPlot.SetViewExtent(wideViewExtent);
            _command.Execute();
            var viewExtent = _scatterPlot.GetViewExtent();
            Assert.That(viewExtent.X, Is.EqualTo(-0.7d).Within(Tolerance));
            Assert.That(viewExtent.Y, Is.EqualTo(-0.1d).Within(Tolerance));
            Assert.That(viewExtent.Width, Is.EqualTo(2.4d).Within(Tolerance));
            Assert.That(viewExtent.Height, Is.EqualTo(1.2d).Within(Tolerance));
        }

        [Test]
        public void TestExecuteShouldZoomToFullExtentIfViewIsTall()
        {
            var wideViewExtent = new Rect(0d, 0d, 1d, 2d);
            _scatterPlot.SetViewExtent(wideViewExtent);
            _command.Execute();
            var viewExtent = _scatterPlot.GetViewExtent();
            Assert.That(viewExtent.X, Is.EqualTo(-0.1d).Within(Tolerance));
            Assert.That(viewExtent.Y, Is.EqualTo(-0.7d).Within(Tolerance));
            Assert.That(viewExtent.Width, Is.EqualTo(1.2d).Within(Tolerance));
            Assert.That(viewExtent.Height, Is.EqualTo(2.4d).Within(Tolerance));
        }

        [Test]
        public void TestExecuteShouldRaiseScatterPlotChangedEvent()
        {
            var wasRaised = false;
            DomainEvents.Register<ScatterPlotChangedEvent>(p => { wasRaised = true; });
            _command.Execute();
            Assert.That(wasRaised, Is.True);
            DomainEvents.ClearHandlers();
        }
    }
}
