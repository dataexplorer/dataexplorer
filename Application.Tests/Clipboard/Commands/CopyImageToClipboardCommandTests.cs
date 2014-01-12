using System.Windows.Media.Imaging;
using DataExplorer.Application.Clipboard;
using DataExplorer.Application.Clipboard.Commands;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Clipboard.Commands
{
    [TestFixture]
    public class CopyImageToClipboardCommandTests
    {
        private CopyImageToClipboardCommandHandler _handler;
        private Mock<ICanvasToBitmapExporter> _mockCanvasExportRender;
        private Mock<IClipboard> _mockClipboard;
        private BitmapSource _bitmap;

        [SetUp]
        public void SetUp()
        {
            _bitmap = new BitmapImage();

            _mockClipboard = new Mock<IClipboard>();

            _mockCanvasExportRender = new Mock<ICanvasToBitmapExporter>();
            _mockCanvasExportRender.Setup(p => p.Export()).Returns(_bitmap);

            _handler = new CopyImageToClipboardCommandHandler(
                _mockCanvasExportRender.Object,
                _mockClipboard.Object);
        }

        [Test]
        public void TestExecuteShouldCopyImageToClipboard()
        {
            _handler.Execute(new CopyImageToClipboardCommand());
            _mockClipboard.Verify(p => p.SetImage(It.IsAny<BitmapSource>()));
        }
    }
}
