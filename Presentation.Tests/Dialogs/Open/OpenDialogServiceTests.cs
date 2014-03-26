using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Application;
using DataExplorer.Presentation.Dialogs;
using DataExplorer.Presentation.Dialogs.Open;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Dialogs.Open
{
    [TestFixture]
    public class OpenDialogServiceTests
    {
        private OpenDialogService _service;
        private Mock<IDialogFactory> _mockFactory;
        private Mock<IOpenFileDialog> _mockOpenDialog;
        private string _filePath;

        [SetUp]
        public void SetUp()
        {
            _filePath = @"C:\Test";

            _mockOpenDialog = new Mock<IOpenFileDialog>();
            _mockOpenDialog.Setup(p => p.ShowDialog())
                .Returns(true);
            _mockOpenDialog.Setup(p => p.GetFilePath())
                .Returns(_filePath);

            _mockFactory = new Mock<IDialogFactory>();
            _mockFactory.Setup(p => p.CreateOpenFileDialog())
                .Returns(_mockOpenDialog.Object);
            
            _service = new OpenDialogService(_mockFactory.Object);
        }

        [Test]
        public void ShowOpenFileDialogShouldDisplayDialog()
        {
            _service.Show();
            _mockOpenDialog.Verify(p => p.SetTitle("Open"), Times.Once());
            _mockOpenDialog.Verify(p => p.SetDefaultExtension(".xml"), Times.Once());
            _mockOpenDialog.Verify(p => p.SetFilter("Data Explorer Projects|*.xml"), Times.Once());
            _mockOpenDialog.Verify(p => p.ShowDialog(), Times.Once());
        }

        [Test]
        public void ShowOpenFileDialogShouldReturnNullIfResultIsFalse()
        {
            _mockOpenDialog.Setup(p => p.ShowDialog())
                .Returns(false);
            var result = _service.Show();
            Assert.That(result, Is.Null);
        }

        [Test]
        public void ShowOpenFileDialogShouldReturnFilePath()
        {
            var result = _service.Show();
            Assert.That(result, Is.EqualTo(_filePath));
        }
    }
}
