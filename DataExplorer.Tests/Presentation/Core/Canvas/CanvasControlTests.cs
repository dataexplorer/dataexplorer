using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Canvas;
using DataExplorer.Presentation.Core.Geometry;
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

        [SetUp]
        public void SetUp()
        {
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
        public void TestSetPlotsShouldSetPlots()
        {
            var plots = new List<Circle>();
            _control.Plots = plots;
            _mockPropertyService.Verify(p => p.SetValue(CanvasControl.PlotsProperty, plots));
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
            var plot = new Circle();
            var plots = new List<Circle> { plot };
            var visual = new DrawingVisual();
            var visuals = new List<Visual> { visual };
            var callback = CanvasControl.PlotsProperty.GetMetadata(_control).PropertyChangedCallback;
            var callback2 = new Action(() => callback.Invoke(_control, new DependencyPropertyChangedEventArgs()));
            _mockPropertyService.Setup(p => p.SetValue(CanvasControl.PlotsProperty, It.IsAny<object>())).Callback(callback2);
            _mockPropertyService.Setup(p => p.GetValue(CanvasControl.PlotsProperty)).Returns(plots);
            _mockRenderer.Setup(p => p.DrawVisual(plot)).Returns(visual);
            _control.Plots = plots;
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
        
        public class CanvasControlHarness : CanvasControl
        {
            public CanvasControlHarness(
                IDependencyPropertyService propertyService,
                ICanvasRenderer renderer,
                IVisualService visualService) 
                : base(propertyService, renderer, visualService)
            {
            }

            public int GetVisualChildrenCount()
            {
                return VisualChildrenCount;
            }

            public new Visual GetVisualChild(int index)
            {
                return base.GetVisualChild(index);
            }

            public new void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
            {
                base.OnRenderSizeChanged(sizeInfo);
            }
        }
    }
}
