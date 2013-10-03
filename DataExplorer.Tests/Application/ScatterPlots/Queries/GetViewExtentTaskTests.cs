using System.Windows;
using DataExplorer.Application.ScatterPlots.Queries;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.ScatterPlots.Queries
{
    [TestFixture]
    public class GetViewExtentQueryTests
    {
        private GetViewExtentQuery _query;
        private Mock<IViewRepository> _mockRepository;
        private ScatterPlot _scatterPlot;
        private Rect _viewExtent;

        [SetUp]
        public void SetUp()
        {
            _viewExtent = new Rect();
            _scatterPlot = new ScatterPlot(_viewExtent, null, null);
            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>()).Returns(_scatterPlot);
            _query = new GetViewExtentQuery(_mockRepository.Object);
        }

        [Test]
        public void TestGetViewExtentShouldReturnViewExtent()
        {
            var result = _query.GetViewExtent();
            Assert.That(result, Is.EqualTo(_viewExtent));
        }
    }
}
