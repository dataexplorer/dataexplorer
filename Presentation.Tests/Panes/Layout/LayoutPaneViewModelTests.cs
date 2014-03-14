using DataExplorer.Presentation.Panes.Layout;
using DataExplorer.Presentation.Panes.Layout.Color;
using DataExplorer.Presentation.Panes.Layout.Label;
using DataExplorer.Presentation.Panes.Layout.Link;
using DataExplorer.Presentation.Panes.Layout.Location;
using DataExplorer.Presentation.Panes.Layout.Shape;
using DataExplorer.Presentation.Panes.Layout.Size;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Layout
{
    [TestFixture]
    public class LayoutPaneViewModelTests
    {
        private LayoutPaneViewModel _paneViewModel;
        private Mock<IXAxisLayoutViewModel> _mockXAxisLayoutViewModel;
        private Mock<IYAxisLayoutViewModel> _mockYAxisLayoutViewModel;
        private Mock<IColorLayoutViewModel> _mockColorLayoutViewModel;
        private Mock<ISizeLayoutViewModel> _mockSizeLayoutViewModel;
        private Mock<IShapeLayoutViewModel> _mockShapeLayoutViewModel;
        private Mock<ILabelLayoutViewModel> _mockLabelLayoutViewModel;
        private Mock<ILinkLayoutViewModel> _mockLinkLayoutViewModel;

        [SetUp]
        public void SetUp()
        {
            _mockXAxisLayoutViewModel = new Mock<IXAxisLayoutViewModel>();
            _mockYAxisLayoutViewModel = new Mock<IYAxisLayoutViewModel>();
            _mockColorLayoutViewModel = new Mock<IColorLayoutViewModel>();
            _mockSizeLayoutViewModel = new Mock<ISizeLayoutViewModel>();
            _mockShapeLayoutViewModel = new Mock<IShapeLayoutViewModel>();
            _mockLabelLayoutViewModel = new Mock<ILabelLayoutViewModel>();
            _mockLinkLayoutViewModel = new Mock<ILinkLayoutViewModel>();

            _paneViewModel = new LayoutPaneViewModel(
                _mockXAxisLayoutViewModel.Object,
                _mockYAxisLayoutViewModel.Object,
                _mockColorLayoutViewModel.Object,
                _mockSizeLayoutViewModel.Object,
                _mockShapeLayoutViewModel.Object,
                _mockLabelLayoutViewModel.Object,
                _mockLinkLayoutViewModel.Object);
        }

        [Test]
        public void TestGetXAxisLayoutViewModelShouldReturnViewModel()
        {
            var result = _paneViewModel.XAxisLayoutViewModel;
            Assert.That(result, Is.EqualTo(_mockXAxisLayoutViewModel.Object));
        }

        [Test]
        public void TestGetYAxisLayoutViewModelShouldReturnViewModel()
        {
            var result = _paneViewModel.YAxisLayoutViewModel;
            Assert.That(result, Is.EqualTo(_mockYAxisLayoutViewModel.Object));
        }

        [Test]
        public void TestGetColorLayoutViewModelShouldReturnViewModel()
        {
            var result = _paneViewModel.ColorLayoutViewModel;
            Assert.That(result, Is.EqualTo(_mockColorLayoutViewModel.Object));
        }

        [Test]
        public void TestGetSizeLayoutViewModelShouldReturnViewModel()
        {
            var result = _paneViewModel.SizeLayoutViewModel;
            Assert.That(result, Is.EqualTo(_mockSizeLayoutViewModel.Object));
        }

        [Test]
        public void TestGetLabelLayoutViewModelShouldReturnViewModel()
        {
            var result = _paneViewModel.LabelLayoutViewModel;
            Assert.That(result, Is.EqualTo(_mockLabelLayoutViewModel.Object));
        }

        [Test]
        public void TestGetLinkLayoutViewModelShouldReturnViewModel()
        {
            var result = _paneViewModel.LinkLayoutViewModel;
            Assert.That(result, Is.EqualTo(_mockLinkLayoutViewModel.Object));
        }
    }
}
