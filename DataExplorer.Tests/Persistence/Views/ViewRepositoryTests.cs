using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Persistence.Views;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Persistence.Views
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

        [Test]
        public void AddViewShouldAddView()
        {
            var view = new ScatterPlot();
            _repository.Add(view);
            _mockViewContext.VerifySet(p => p.ScatterPlot = view, Times.Once());
        }
    }
}
