using DataExplorer.Presentation.Panes.Layout;
using DataExplorer.Presentation.Views.ScatterPlots.Layout;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Layout
{
    [TestFixture]
    public class LayoutPaneViewModelTests
    {
        private LayoutPaneViewModel _viewModel;
        private Mock<IScatterPlotLayoutViewModel> _mockScatterPlotLayoutViewModel;

        [SetUp]
        public void SetUp()
        {
            _mockScatterPlotLayoutViewModel = new Mock<IScatterPlotLayoutViewModel>();
            _viewModel = new LayoutPaneViewModel(_mockScatterPlotLayoutViewModel.Object);
        }

        [Test]
        public void TestGetScatterPlotLayoutViewModelShouldReturnViewModel()
        {
            var result = _viewModel.ScatterPlotLayoutViewModel;
            Assert.That(result, Is.EqualTo(_mockScatterPlotLayoutViewModel.Object));
        }
    }
}
