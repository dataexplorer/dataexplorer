using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Presentation.Shell.MainMenu.ViewMenu;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Shell.MainMenu.ViewMenu
{
    [TestFixture]
    public class ViewMenuViewModelTests
    {
        private ViewMenuViewModel _viewModel;
        private Mock<IScatterPlotService> _mockScatterPlotService; 

        [SetUp]
        public void SetUp()
        {
            _mockScatterPlotService = new Mock<IScatterPlotService>();
            _viewModel = new ViewMenuViewModel(_mockScatterPlotService.Object);
        }

        [Test]
        public void TestZoomToFullExtentShouldZoomToFullExtent()
        {
            _viewModel.ZoomToFullExtentCommand.Execute(null);
            _mockScatterPlotService.Verify(p => p.ZoomToFullExtent(), Times.Once());
        }
    }
}
