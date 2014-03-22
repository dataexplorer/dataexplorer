using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots.Events;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Tests.Core;
using DataExplorer.Presentation.Tests.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotViewModelTests : ViewModelTests
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
            _mockQueries.Setup(p => p.GetItems(It.IsAny<Size>()))
                .Returns(_items);
            _mockQueries.Setup(p => p.GetSelectedItems(_items))
                .Returns(_items);
            
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
        public void TestExecuteShouldExecuteLink()
        {
            _viewModel.HandleExecute(1);
            _mockCommands.Verify(p => p.Execute(1), Times.Once());
        }

        [Test]
        public void TestHandleProjectOpenedShouldClearSelectedItems()
        {
            AssertPropertyChanged(_viewModel, () => _viewModel.SelectedItems,
                () => _viewModel.Handle(new ProjectOpenedEvent()));
        }

        [Test]
        public void TestHandleProjectClosedShouldClearSelectedItems()
        {
            AssertPropertyChanged(_viewModel, () => _viewModel.SelectedItems, 
                () => _viewModel.Handle(new ProjectClosedEvent()));
        }

        [Test]
        public void TestHandleSourceImportedShouldClearSelectedItems()
        {
            AssertPropertyChanged(_viewModel, () => _viewModel.SelectedItems,
                () => _viewModel.Handle(new SourceImportedEvent()));
        }

        [Test]
        public void TestIsValidLayoutDropSourceShouldAlwaysReturnTrue()
        {
            Assert.That(_viewModel.IsValidLayoutDropSource(null), Is.True);
        }

        [Test]
        public void TestSetDragDropLayoutShouldExecuteAutoAssignLayoutCommand()
        {
            var column = new ColumnBuilder().WithId(1).Build();
            _viewModel.HandleSetDragDropLayout(column);
            _mockCommands.Verify(p => p.Layout(1), Times.Once());
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
