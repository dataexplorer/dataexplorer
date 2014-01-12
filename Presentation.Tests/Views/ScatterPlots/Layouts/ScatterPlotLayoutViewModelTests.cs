using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Views.ScatterPlots.Layout;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.Layouts
{
    [TestFixture]
    public class ScatterPlotLayoutViewModelTests
    {
        private ScatterPlotLayoutViewModel _viewModel;
        private Mock<IXAxisLayoutViewModel> _mockXAxisLayoutViewModel;
        private Mock<IYAxisLayoutViewModel> _mockYAxisLayoutViewModel;

        [SetUp]
        public void SetUp()
        {
            _mockXAxisLayoutViewModel = new Mock<IXAxisLayoutViewModel>();
            _mockYAxisLayoutViewModel = new Mock<IYAxisLayoutViewModel>();
            _viewModel = new ScatterPlotLayoutViewModel(
                _mockXAxisLayoutViewModel.Object,
                _mockYAxisLayoutViewModel.Object);
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
    }
}
