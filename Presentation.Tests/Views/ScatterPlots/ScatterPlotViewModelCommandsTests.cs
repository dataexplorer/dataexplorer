using System.Collections.Generic;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Tests.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots;
using DataExplorer.Presentation.Views.ScatterPlots.Commands;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotViewModelCommandsTests
    {
        private ScatterPlotViewModelCommands _commands;
        private Mock<IResizeScatterPlotViewExtentCommand> _mockResizeCommand;
        private Mock<IZoomInScatterPlotCommand> _mockZoomInCommand;
        private Mock<IZoomOutScatterPlotCommand> _mockZoomOutCommand;
        private Mock<IPanScatterPlotCommand> _mockPanCommand;
        private Mock<ISelectCommand> _mockSelectCommand;

        [SetUp]
        public void SetUp()
        {
            _mockResizeCommand = new Mock<IResizeScatterPlotViewExtentCommand>();
            _mockZoomInCommand = new Mock<IZoomInScatterPlotCommand>();
            _mockZoomOutCommand = new Mock<IZoomOutScatterPlotCommand>();
            _mockPanCommand = new Mock<IPanScatterPlotCommand>();
            _mockSelectCommand = new Mock<ISelectCommand>();

            _commands = new ScatterPlotViewModelCommands(
                _mockResizeCommand.Object,
                _mockZoomInCommand.Object,
                _mockZoomOutCommand.Object,
                _mockPanCommand.Object,
                _mockSelectCommand.Object);
        }

        [Test]
        public void TestResizeShouldExecuteResizeCommand()
        {
            var controlSize = new Size();
            _commands.Resize(controlSize);
            _mockResizeCommand.Verify(p => p.Execute(controlSize));
        }

        [Test]
        public void TestZoomInShouldExecuteZoomInCommand()
        {
            var center = new Point();
            var size = new Size();
            _commands.ZoomIn(center, size);
            _mockZoomInCommand.Verify(p => p.Execute(center, size));
        }

        [Test]
        public void TestZoomOutShouldExecuteZoomOutCommand()
        {
            var center = new Point();
            var size = new Size();
            _commands.ZoomOut(center, size);
            _mockZoomOutCommand.Verify(p => p.Execute(center, size));
        }

        [Test]
        public void TestPanShouldExecutePanCommand()
        {
            var vector = new Vector();
            var size = new Size();
            _commands.Pan(vector, size);
            _mockPanCommand.Verify(p => p.Execute(vector, size));
        }

        [Test]
        public void TestSelectShouldExecuteSelectCommand()
        {
            var item = new FakeCanvasItem();
            var items = new List<CanvasItem> { item };
            _commands.Select(items);
            _mockSelectCommand.Verify(p => p.Execute(items));
        }
    }
}
