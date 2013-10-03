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
        private Mock<IScatterPlotService> _mockService;

        [SetUp]
        public void SetUp()
        {
            _mockService = new Mock<IScatterPlotService>();

            _viewModel = new ScatterPlotContextMenuViewModel(
                _mockService.Object);
        }

        [Test]
        public void TestExecuteZoomToFullExtentShouldZoomToFullExtent()
        {
            _viewModel.ZoomToFullExtentCommand.Execute(null);
            _mockService.Verify(p => p.ZoomToFullExtent(), Times.Once());
        }
    }
}
