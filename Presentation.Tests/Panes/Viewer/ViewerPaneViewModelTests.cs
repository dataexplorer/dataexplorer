using DataExplorer.Presentation.Panes.Viewer;
using DataExplorer.Presentation.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Viewer
{
    [TestFixture]
    public class ViewerPaneViewModelTests
    {
        private ViewerPaneViewModel _viewModel;
        private Mock<IScatterPlotViewModel> _mockScatterPlotViewModel;

        [SetUp]
        public void SetUp()
        {
            _mockScatterPlotViewModel = new Mock<IScatterPlotViewModel>();
            _viewModel = new ViewerPaneViewModel(_mockScatterPlotViewModel.Object);
        }

        [Test]
        public void TestGetScatterPlotViewModelReturnsScatterPlotViewModel()
        {
            var result = _viewModel.ScatterPlotViewModel;
            Assert.That(result, Is.EqualTo(_mockScatterPlotViewModel.Object));
        }
    }
}
