using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots;
using DataExplorer.Presentation.Views.ScatterPlots.Commands;
using DataExplorer.Presentation.Views.ScatterPlots.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotViewModelTests
    {
        private ScatterPlotViewModel _viewModel;
        private Mock<IScatterPlotContextMenuViewModel> _mockContextMenuViewModel;
        private Mock<IGetScatterPlotItemsQuery> _mockGetItemsQuery;
        private Mock<IResizeScatterPlotViewExtentCommand> _mockResizeCommand;
        private Mock<IZoomInScatterPlotCommand> _mockZoomInCommand;
        private Mock<IZoomOutScatterPlotCommand> _mockZoomOutCommand;
        private Mock<IPanScatterPlotCommand> _mockPanCommand;
        private Size _controlSize;
        private List<ICanvasItem> _items;
        private ICanvasItem _item;
        
        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size();
            _item = new CanvasCircle();
            _items = new List<ICanvasItem> { _item };

            _mockContextMenuViewModel = new Mock<IScatterPlotContextMenuViewModel>();
            
            _mockGetItemsQuery = new Mock<IGetScatterPlotItemsQuery>();
            _mockGetItemsQuery.Setup(p => p.Execute(It.IsAny<Size>())).Returns(_items);
            
            _mockResizeCommand = new Mock<IResizeScatterPlotViewExtentCommand>();
            _mockZoomInCommand = new Mock<IZoomInScatterPlotCommand>();
            _mockZoomOutCommand = new Mock<IZoomOutScatterPlotCommand>();
            _mockPanCommand = new Mock<IPanScatterPlotCommand>();

            _viewModel = new ScatterPlotViewModel(
                _mockContextMenuViewModel.Object,
                _mockGetItemsQuery.Object,
                _mockResizeCommand.Object,
                _mockZoomInCommand.Object,
                _mockZoomOutCommand.Object,
                _mockPanCommand.Object);
        }

        [Test]
        public void TestGetContextMenuViewModelShouldReturnViewModel()
        {
            var result = _viewModel.ContextMenuViewModel;
            Assert.That(result, Is.EqualTo(_mockContextMenuViewModel.Object));
        }

        [Test]
        public void TestSetControlSizeShouldResizeViewExtent()
        {
            _viewModel.ControlSize = _controlSize;
            _mockResizeCommand.Verify(p => p.Execute(_controlSize), Times.Once());
        }

        [Test]
        public void TestGetItemsShouldReturnItems()
        {
            var results = _viewModel.Items;
            Assert.That(results.Single(), Is.EqualTo(_item));
        }

        [Test]
        public void TestZoomInShouldExecuteCommand()
        {
            var point = new Point();
            _viewModel.HandleZoomIn(point);
            _mockZoomInCommand.Verify(p => p.Execute(point, _controlSize), Times.Once());
        }

        [Test]
        public void TestZoomOutShouldExecuteCommand()
        {
            var point = new Point();
            _viewModel.HandleZoomOut(point);
            _mockZoomOutCommand.Verify(p => p.Execute(point, _controlSize), Times.Once());
        }
        
        [Test]
        public void TestPanShouldScalePanValues()
        {
            var vector = new Vector();
            _viewModel.HandlePan(vector);
            _mockPanCommand.Verify(p => p.Execute(vector, _controlSize), Times.Once());
        }

        [Test]
        public void TestHandleScatterPlotChangedEventShouldRaisePlotPropertyChangedEvent()
        {
            var wasPropertyChangeEventRaised = false;
            _viewModel.PropertyChanged += (s, e) => { wasPropertyChangeEventRaised = true; };
            _viewModel.Handle(new ScatterPlotChangedEvent());
            Assert.That(wasPropertyChangeEventRaised, Is.EqualTo(true));
        }
    }
}
