using DataExplorer.Domain.ScatterPlot;
using DataExplorer.Persistence.View;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Persistence.View
{
    [TestFixture]
    public class ViewRepositoryTests
    {
        private ViewRepository _repository;
        private Mock<IViewContext> _mockViewContext;
        private Mock<IScatterPlot> _mockScatterPlot;

        [SetUp]
        public void SetUp()
        {
            _mockScatterPlot = new Mock<IScatterPlot>();
            _mockViewContext = new Mock<IViewContext>();
            _repository = new ViewRepository(_mockViewContext.Object);
        }

        [Test]
        public void GetScatterPlotReturnsScatterPlot()
        {
            _mockViewContext.SetupGet(p => p.ScatterPlot).Returns(_mockScatterPlot.Object);
            var result = _repository.GetScatterPlot();
            Assert.That(result, Is.EqualTo(_mockScatterPlot.Object));
        }
    }
}
