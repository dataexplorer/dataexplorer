using System.Windows;
using DataExplorer.Application.Views;
using DataExplorer.Application.Views.ScatterPlots.Commands;
using DataExplorer.Domain.Core.Events;
using DataExplorer.Domain.Tests.Views.ScatterPlots;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots.Events;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots.Commands
{
    [TestFixture]
    public class ZoomToFullExtentCommandHandlerTests
    {
        private const double Tolerance = 0.000001;

        private ZoomToFullExtentCommandHandler _handler;
        private Mock<IViewRepository> _mockRepository;
        private ScatterPlot _scatterPlot;

        [SetUp]
        public void SetUp()
        {
            _scatterPlot = new ScatterPlotBuilder().Build();
            
            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>()).Returns(_scatterPlot);
            
            _handler = new ZoomToFullExtentCommandHandler(_mockRepository.Object);
        }

        [Test]
        public void TestExecuteShouldZoomToFullExtentIfViewIsSquare()
        {
            var squareViewExtent = new Rect(0d, 0d, 1d, 1d);
            _scatterPlot.SetViewExtent(squareViewExtent);
            _handler.Execute(new ZoomToFullExtentCommand());
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
            _handler.Execute(new ZoomToFullExtentCommand());
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
            _handler.Execute(new ZoomToFullExtentCommand());
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
            _handler.Execute(new ZoomToFullExtentCommand());
            Assert.That(wasRaised, Is.True);
            DomainEvents.ClearHandlers();
        }
    }
}
