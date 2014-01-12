using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Presentation.Views.ScatterPlots.Commands;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.Commands
{
    [TestFixture]
    public class ResizeScatterPlotViewExtentCommandTests
    {
        private ResizeScatterPlotViewExtentCommand _command;
        private Mock<IScatterPlotService> _mockService;
        private Mock<IViewResizer> _mockResizer;
        private Size _controlSize;
        private Rect _viewExtent;
        private Rect _newViewExtent;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size();
            _viewExtent = new Rect();
            _newViewExtent = new Rect();

            _mockService = new Mock<IScatterPlotService>();
            _mockService.Setup(p => p.GetViewExtent()).Returns(_viewExtent);

            _mockResizer = new Mock<IViewResizer>();
            _mockResizer.Setup(p => p.ResizeView(_controlSize, _viewExtent)).Returns(_newViewExtent);

            _command = new ResizeScatterPlotViewExtentCommand(
                _mockService.Object,
                _mockResizer.Object);
        }

        [Test]
        public void TestExecuteShouldResizeViewExtent()
        {
            _command.Execute(_controlSize);
            _mockService.Verify(p => p.SetViewExtent(_newViewExtent), Times.Once());
        }

    }
}
