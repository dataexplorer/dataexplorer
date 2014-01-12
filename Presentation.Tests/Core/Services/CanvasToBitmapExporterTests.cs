using System;
using System.Windows;
using System.Windows.Media.Imaging;
using DataExplorer.Presentation.Core.Canvas;
using DataExplorer.Presentation.Core.Services;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Core.Services
{
    [TestFixture]
    public class CanvasToBitmapExporterTests
    {
        private CanvasToBitmapExporter _exporter;
        private Mock<IWindowService> _mockWindowService;
        private Mock<IControlFinder> _mockFinder;
        private Mock<IControlToBitmapRenderer> _mockRenderer;
        private Window _window;
        private CanvasControl _canvas;
        private BitmapSource _image;

        [SetUp]
        public void SetUp()
        {
            _window = new Window();
            _canvas = new CanvasControl();
            _image = new BitmapImage();

            _mockWindowService = new Mock<IWindowService>();
            _mockWindowService.Setup(p => p.GetMainWindow()).Returns(_window);

            _mockFinder = new Mock<IControlFinder>();
            _mockFinder.Setup(p => p.Find<CanvasControl>(_window)).Returns(_canvas);

            _mockRenderer = new Mock<IControlToBitmapRenderer>();
            _mockRenderer.Setup(p => p.Render(_canvas)).Returns(_image);

            _exporter = new CanvasToBitmapExporter(
                _mockWindowService.Object,
                _mockFinder.Object,
                _mockRenderer.Object);
        }

        [Test]
        [STAThread]
        public void TestExportShouldReturnBitmapOfCanvas()
        {
            var result = _exporter.Export();
            Assert.That(result, Is.EqualTo(_image));
        }
    }
}
