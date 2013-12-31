using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Presentation.Core;
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
        private Mock<IScatterPlotViewModelQueries> _mockQueries;
        private Mock<IScatterPlotViewModelCommands> _mockCommands;
        private Size _controlSize;
        private List<CanvasItem> _items;
        private CanvasItem _item;
        
        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size();
            _item = new CanvasCircle();
            _items = new List<CanvasItem> { _item };

            _mockContextMenuViewModel = new Mock<IScatterPlotContextMenuViewModel>();
            
            _mockQueries = new Mock<IScatterPlotViewModelQueries>();
            _mockQueries.Setup(p => p.GetItems(It.IsAny<Size>())).Returns(_items);
            _mockQueries.Setup(p => p.GetSelectedItems(_items)).Returns(_items);
            
            _mockCommands = new Mock<IScatterPlotViewModelCommands>();
            
            _viewModel = new ScatterPlotViewModel(
                _mockContextMenuViewModel.Object,
                _mockQueries.Object,
                _mockCommands.Object);
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
            _mockCommands.Verify(p => p.Resize(_controlSize), Times.Once());
        }

        [Test]
        public void TestGetItemsShouldReturnItems()
        {
            var results = _viewModel.Items;
            Assert.That(results.Single(), Is.EqualTo(_item));
        }

        [Test]
        public void TestGetSelectedItemsShouldReturnItems()
        {
            _viewModel.SelectedItems.Add(_item);
            var results = _viewModel.SelectedItems;
            Assert.That(results.Single(), Is.EqualTo(_item));
        }

        [Test]
        public void TestSelectedItemsCollectionChangedShouldExecuteSelectCommand()
        {
            _viewModel.SelectedItems.Add(_item);
            _mockCommands.Verify(p => p.Select(_items));
        }
        
        [Test]
        public void TestZoomInShouldExecuteCommand()
        {
            var point = new Point();
            _viewModel.HandleZoomIn(point);
            _mockCommands.Verify(p => p.ZoomIn(point, _controlSize), Times.Once());
        }

        [Test]
        public void TestZoomOutShouldExecuteCommand()
        {
            var point = new Point();
            _viewModel.HandleZoomOut(point);
            _mockCommands.Verify(p => p.ZoomOut(point, _controlSize), Times.Once());
        }

        [Test]
        public void TestPanShouldScalePanValues()
        {
            var vector = new Vector();
            _viewModel.HandlePan(vector);
            _mockCommands.Verify(p => p.Pan(vector, _controlSize), Times.Once());
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
