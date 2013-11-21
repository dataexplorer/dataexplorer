using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Canvas;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Tests.Presentation.Core.Canvas.Items;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Core.Canvas
{
    [TestFixture, RequiresSTA]
    public class CanvasControlTests
    {
        private CanvasControlHarness _control;
        private Mock<IDependencyPropertyService> _mockPropertyService;
        private Mock<ICanvasRenderer> _mockRenderer;
        private Mock<IVisualService> _mockVisualService;
        private List<CanvasItem> _items;
        private CanvasItem _item;

        [SetUp]
        public void SetUp()
        {
            _item = new FakeCanvasItem();
            _items = new List<CanvasItem> { _item };

            _mockPropertyService = new Mock<IDependencyPropertyService>();
            _mockRenderer = new Mock<ICanvasRenderer>();
            _mockVisualService = new Mock<IVisualService>();
            _control = new CanvasControlHarness(
                _mockPropertyService.Object,
                _mockRenderer.Object,
                _mockVisualService.Object);
        }

        [Test]
        public void TestGetControlSizeShouldGetControlSize()
        {
            var controlSize = new Size(1, 2);
            _mockPropertyService.Setup(p => p.GetValue(CanvasControl.ControlSizeProperty)).Returns(controlSize);
            var result = _control.ControlSize;
            Assert.That(result, Is.EqualTo(controlSize));
        }

        [Test]
        public void TestSetControlSizeShouldSetControlSize()
        {
            var controlSize = new Size(1, 2);
            _control.ControlSize = controlSize;
            _mockPropertyService.Verify(p => p.SetValue(CanvasControl.ControlSizeProperty, controlSize), Times.Once());
        }

        [Test]
        public void TestSetItemsShouldSetItems()
        {
            _control.Items = _items;
            _mockPropertyService.Verify(p => p.SetValue(CanvasControl.ItemsProperty, _items));
        }

        [Test]
        public void TestGetSelectedItemsShouldReturnSelectedItems()
        {
            _item.IsSelected = true;
            _mockPropertyService.Setup(p => p.GetValue(CanvasControl.SelectedItemsProperty)).Returns(_items);
            var results = _control.SelectedItems;
            Assert.That(results.Single(), Is.EqualTo(_item));
        }

        [Test]
        public void TestConstructorShouldSetSourceOfDependencyPropertyServiceToSelf()
        {
            _mockPropertyService.Verify(p => p.SetSource(_control), Times.Once());
        }

        [Test]
        public void TestConstructorShouldSetSourceOfVisualServiceToSelf()
        {
            _mockVisualService.Verify(p => p.SetSource(_control), Times.Once());
        }

        [Test]
        public void TestSetPlotsShouldRenderPlots()
        {
            var plot = new CanvasCircle();
            var plots = new List<CanvasItem> { plot };
            var backgroundVisual = new FakeVisual();
            var plotVisual = new FakeVisual();
            var plotVisuals = new List<Visual> { plotVisual };
            var visuals = new List<Visual> { backgroundVisual, plotVisual };
            var callback = CanvasControl.ItemsProperty.GetMetadata(_control).PropertyChangedCallback;
            var callback2 = new Action(() => callback.Invoke(_control, new DependencyPropertyChangedEventArgs()));
            _mockPropertyService.Setup(p => p.SetValue(CanvasControl.ItemsProperty, It.IsAny<object>())).Callback(callback2);
            _mockPropertyService.Setup(p => p.GetValue(CanvasControl.ItemsProperty)).Returns(plots);
            _mockPropertyService.Setup(p => p.GetValue(CanvasControl.SelectedItemsProperty)).Returns(new List<CanvasItem>());
            _mockRenderer.Setup(p => p.DrawBackground(0d, 0d)).Returns(backgroundVisual);
            _mockRenderer.Setup(p => p.DrawItems(plots)).Returns(plotVisuals);
            _control.Items = plots;
            _mockVisualService.Verify(p => p.Clear(), Times.Once());
            _mockVisualService.Verify(p => p.Add(visuals));
        }
        
        [Test]
        public void TestGetVisualChildrenCountShouldReturnCountFromVisualService()
        {
            _mockVisualService.Setup(p => p.GetVisualsCount()).Returns(1);
            var result = _control.GetVisualChildrenCount();
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void TestGetVisualChildShouldReturnVisualFromVisualService()
        {
            var visual = new FakeVisual();
            _mockVisualService.Setup(p => p.GetVisual(1)).Returns(visual);
            var result = _control.GetVisualChild(1);
            Assert.That(result, Is.EqualTo(visual));
        }

        [Test]
        public void TestOnRenderSizeChangedShouldSetControlSize()
        {
            var sizeInfo = new SizeChangedInfo(_control, new Size(0, 0), false, false);
            _control.OnRenderSizeChanged(sizeInfo);
            _mockPropertyService.Verify(p => p.SetValue(
                It.IsAny<DependencyProperty>(), 
                It.IsAny<Size>()));
        }
    }
}
