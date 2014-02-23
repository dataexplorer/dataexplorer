using DataExplorer.Presentation.Panes.Layout;
using DataExplorer.Presentation.Panes.Layout.Color;
using DataExplorer.Presentation.Panes.Layout.XAxis;
using DataExplorer.Presentation.Panes.Layout.YAxis;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Layout
{
    [TestFixture]
    public class ScatterPlotLayoutViewModelTests
    {
        private ScatterPlotLayoutViewModel _viewModel;
        private Mock<IXAxisLayoutViewModel> _mockXAxisLayoutViewModel;
        private Mock<IYAxisLayoutViewModel> _mockYAxisLayoutViewModel;
        private Mock<IColorLayoutViewModel> _mockColorLayoutViewModel;

        [SetUp]
        public void SetUp()
        {
            _mockXAxisLayoutViewModel = new Mock<IXAxisLayoutViewModel>();
            _mockYAxisLayoutViewModel = new Mock<IYAxisLayoutViewModel>();
            _mockColorLayoutViewModel = new Mock<IColorLayoutViewModel>();

            _viewModel = new ScatterPlotLayoutViewModel(
                _mockXAxisLayoutViewModel.Object,
                _mockYAxisLayoutViewModel.Object,
                _mockColorLayoutViewModel.Object);
        }

        [Test]
        public void TestGetXAxisLayoutViewModelShouldReturnViewModel()
        {
            var result = _viewModel.XAxisLayoutViewModel;
            Assert.That(result, Is.EqualTo(_mockXAxisLayoutViewModel.Object));
        }

        [Test]
        public void TestGetYAxisLayoutViewModelShouldReturnViewModel()
        {
            var result = _viewModel.YAxisLayoutViewModel;
            Assert.That(result, Is.EqualTo(_mockYAxisLayoutViewModel.Object));
        }

        [Test]
        public void TestGetColorLayoutViewModelShouldReturnViewModel()
        {
            var result = _viewModel.ColorLayoutViewModel;
            Assert.That(result, Is.EqualTo(_mockColorLayoutViewModel.Object));
        }
    }
}
