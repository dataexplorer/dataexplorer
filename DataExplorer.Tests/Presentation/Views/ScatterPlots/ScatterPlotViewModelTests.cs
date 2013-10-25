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
using DataExplorer.Presentation.Views.ScatterPlots.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.Renderers;
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
        private Mock<IScatterPlotService> _mockService;
        private Mock<IViewResizer> _mockResizer;
        private Mock<IScatterPlotViewScaler> _mockScaler;
        private Size _controlSize;
        private Rect _viewExtent;
        private List<ICanvasItem> _items;
        private ICanvasItem _item;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size(100, 100);
            _viewExtent = new Rect(0, 0, 1, 1);
            _item = new CanvasCircle();
            _items = new List<ICanvasItem> { _item };

            _mockContextMenuViewModel = new Mock<IScatterPlotContextMenuViewModel>();
            
            _mockGetItemsQuery = new Mock<IGetScatterPlotItemsQuery>();
            _mockGetItemsQuery.Setup(p => p.Execute(It.IsAny<Size>())).Returns(_items);

            _mockService = new Mock<IScatterPlotService>();
            _mockService.Setup(p => p.GetViewExtent()).Returns(_viewExtent);

            _mockResizer = new Mock<IViewResizer>();

            _mockScaler = new Mock<IScatterPlotViewScaler>();
            
            _viewModel = new ScatterPlotViewModel(
                _mockContextMenuViewModel.Object,
                _mockGetItemsQuery.Object,
                _mockService.Object, 
                _mockResizer.Object,
                _mockScaler.Object);
        }

        [Test]
        public void TestSetControlSizeShouldResizeViewExtent()
        {
            _controlSize = new Size();
            _viewExtent = new Rect();
            var newViewExtent = new Rect();
            _mockResizer.Setup(p => p.ResizeView(_controlSize, _viewExtent)).Returns(newViewExtent);
            _viewModel.ControlSize = _controlSize;
            _mockService.Verify(p => p.SetViewExtent(newViewExtent), Times.Once());
        }

        [Test]
        public void TestGetItemsShouldReturnItems()
        {
            var results = _viewModel.Items;
            Assert.That(results.Single(), Is.EqualTo(_item));
        }

        [Test]
        public void TestGetContextMenuViewModelShouldReturnViewModel()
        {
            var result = _viewModel.ContextMenuViewModel;
            Assert.That(result, Is.EqualTo(_mockContextMenuViewModel.Object));
        }

        [Test]
        public void TestHandleScatterPlotChangedEventShouldRaisePlotPropertyChangedEvent()
        {
            var wasPropertyChangeEventRaised = false;
            _viewModel.PropertyChanged += (s, e) => { wasPropertyChangeEventRaised = true; };
            _viewModel.Handle(new ScatterPlotChangedEvent());
            Assert.That(wasPropertyChangeEventRaised, Is.EqualTo(true));
        }

        [Test]
        public void TestZoomInShouldScaleZoomInValues()
        {
            var point = new Point(25, 50);
            var scaledPoint = new Point(0.25, -0.50);
            _viewModel.ControlSize = _controlSize;
            _mockScaler.Setup(p => p.ScalePoint(point, _controlSize, _viewExtent)).Returns(scaledPoint);
            _viewModel.HandleZoomIn(point);
            _mockService.Verify(p => p.ZoomIn(scaledPoint));                  
        }

        [Test]
        public void TestZoomOutShouldScaleZoomOutValues()
        {
            var point = new Point(25, 50);
            var scaledPoint = new Point(0.25, -0.50);
            _viewModel.ControlSize = _controlSize;
            _mockScaler.Setup(p => p.ScalePoint(point, _controlSize, _viewExtent)).Returns(scaledPoint);
            _viewModel.HandleZoomOut(point);
            _mockService.Verify(p => p.ZoomOut(scaledPoint));   
        }

        [Test]
        public void TestPanShouldScalePanValues()
        {
            var vector = new Vector(25, 50);
            var scaledVector = new Vector(0.25, -0.50);
            _viewModel.ControlSize = _controlSize;
            _mockScaler.Setup(p => p.ScaleVector(vector, _controlSize, _viewExtent)).Returns(scaledVector);
            _viewModel.HandlePan(vector);
            _mockService.Verify(p => p.Pan(scaledVector));
        }
    }
}
