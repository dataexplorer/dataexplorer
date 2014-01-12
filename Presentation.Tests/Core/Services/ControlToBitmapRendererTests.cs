using System;
using System.Windows;
using System.Windows.Media.Imaging;
using DataExplorer.Presentation.Core.Services;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Core.Services
{
    [TestFixture]
    public class ControlToBitmapRendererTests
    {
        private ControlToBitmapRenderer _renderer;
        private FakeControl _control;
        
        [SetUp]
        public void SetUp()
        {
            _control = new FakeControl();
            _control.Width = 10;
            _control.Height = 20;
            _control.Measure(new Size(_control.Width, _control.Height));
            _control.Arrange(new Rect(new Size(_control.Width, _control.Height)));

            _renderer = new ControlToBitmapRenderer();
        }

        [Test]
        [STAThread]
        public void TestRenderShouldCreateBitmap()
        {
            var result = _renderer.Render(_control);
            Assert.That(result, Is.TypeOf<RenderTargetBitmap>());
            Assert.That(result.Width, Is.EqualTo(10));
            Assert.That(result.Height, Is.EqualTo(20));
            Assert.That(result.DpiX, Is.EqualTo(96));
            Assert.That(result.DpiY, Is.EqualTo(96));
        }
    }
}
