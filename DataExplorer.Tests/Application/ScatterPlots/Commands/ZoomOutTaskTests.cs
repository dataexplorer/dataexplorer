using System.Windows;
using DataExplorer.Application.ScatterPlots.Commands;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.ScatterPlots.Commands
{
    [TestFixture]
    public class ZoomOutCommandTests
    {
        private ZoomOutCommand _command;
        private Mock<IViewRepository> _mockRepository;
        private ScatterPlot _scatterPlot;
        private Rect _viewExtent;
        private Point _point;

        [SetUp]
        public void SetUp()
        {
            _point = new Point(50d, 50d);
            _viewExtent = new Rect(0, 0, 100, 100);
            _scatterPlot = new ScatterPlot(_viewExtent, null, null);
            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>()).Returns(_scatterPlot);
            _command = new ZoomOutCommand(_mockRepository.Object);
        }

        [Test]
        public void TestZoomOutShouldZoomOutByZoomFactor()
        {
            _command.ZoomOut(_point);
            var viewExtent = _scatterPlot.GetViewExtent();
            Assert.That(viewExtent.X, Is.EqualTo(-11));
            Assert.That(viewExtent.Y, Is.EqualTo(-11));
            Assert.That(viewExtent.Width, Is.EqualTo(111));
            Assert.That(viewExtent.Height, Is.EqualTo(111));
        }
    }
}
