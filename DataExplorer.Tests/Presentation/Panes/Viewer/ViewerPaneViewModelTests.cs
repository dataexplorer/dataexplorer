using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Panes.Viewer;
using DataExplorer.Presentation.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Panes.Viewer
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
