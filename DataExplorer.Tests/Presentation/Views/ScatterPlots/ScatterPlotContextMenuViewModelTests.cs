using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Presentation.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotContextMenuViewModelTests
    {
        private ScatterPlotContextMenuViewModel _viewModel;
        private Mock<IScatterPlotService> _mockScatterPlotService;
        private Mock<IScatterPlotLayoutService> _mockLayoutService;

        [SetUp]
        public void SetUp()
        {
            _mockScatterPlotService = new Mock<IScatterPlotService>();

            _mockLayoutService = new Mock<IScatterPlotLayoutService>();

            _viewModel = new ScatterPlotContextMenuViewModel(
                _mockScatterPlotService.Object,
                _mockLayoutService.Object);
        }

        [Test]
        public void TestExecuteZoomToFullExtentShouldZoomToFullExtent()
        {
            _viewModel.ZoomToFullExtentCommand.Execute(null);
            _mockScatterPlotService.Verify(p => p.ZoomToFullExtent(), Times.Once());
        }

        [Test]
        public void TestExecuteClearLayoutShouldClearLayout()
        {
            _viewModel.ClearLayoutCommand.Execute(null);
            _mockLayoutService.Verify(p => p.ClearLayout(), Times.Once());
        }
    }
}
