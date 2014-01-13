using System.Windows;
using DataExplorer.Application.Views.ScatterPlots.Commands;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots.Commands
{
    [TestFixture]
    public class ZoomOutCommandHandlerTests
    {
        private ZoomOutCommandHandler _handler;
        private Mock<IViewRepository> _mockRepository;
        private ScatterPlot _scatterPlot;
        private Rect _viewExtent;
        private Point _point;

        [SetUp]
        public void SetUp()
        {
            _point = new Point(50d, 50d);
            _viewExtent = new Rect(0, 0, 100, 100);
            _scatterPlot = new ScatterPlot(null, _viewExtent, null);
            
            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>()).Returns(_scatterPlot);

            _handler = new ZoomOutCommandHandler(_mockRepository.Object);
        }

        [Test]
        public void TestZoomOutShouldZoomOutByZoomFactor()
        {
            _handler.Execute(new ZoomOutCommand(_point));
            var viewExtent = _scatterPlot.GetViewExtent();
            Assert.That(viewExtent.X, Is.EqualTo(-11));
            Assert.That(viewExtent.Y, Is.EqualTo(-11));
            Assert.That(viewExtent.Width, Is.EqualTo(111));
            Assert.That(viewExtent.Height, Is.EqualTo(111));
        }
    }
}
