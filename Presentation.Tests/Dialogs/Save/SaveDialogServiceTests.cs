using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Dialogs;
using DataExplorer.Presentation.Dialogs.Save;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Dialogs.Save
{
    public class SaveDialogServiceTests
    {
        private SaveDialogService _service;
        private Mock<IDialogFactory> _mockFactory;
        private Mock<ISaveFileDialog> _mockSaveDialog;
        private string _filePath;

        [SetUp]
        public void SetUp()
        {
            _filePath = @"C:\Test";

            _mockSaveDialog = new Mock<ISaveFileDialog>();
            _mockSaveDialog.Setup(p => p.ShowDialog())
                .Returns(true);
            _mockSaveDialog.Setup(p => p.GetFilePath())
                .Returns(_filePath);

            _mockFactory = new Mock<IDialogFactory>();
            _mockFactory.Setup(p => p.CreateSaveFileDialog())
                .Returns(_mockSaveDialog.Object);

            _service = new SaveDialogService(_mockFactory.Object);
        }

        [Test]
        public void ShowSaveFileDialogShouldDisplayDialog()
        {
            _service.Show();
            _mockSaveDialog.Verify(p => p.SetTitle("Save"), Times.Once());
            _mockSaveDialog.Verify(p => p.SetDefaultExtension(".xml"), Times.Once());
            _mockSaveDialog.Verify(p => p.SetFilter("Data Explorer Projects|*.xml"), Times.Once());
            _mockSaveDialog.Verify(p => p.ShowDialog(), Times.Once());
        }

        [Test]
        public void ShowSaveFileDialogShouldReturnNullIfResultIsFalse()
        {
            _mockSaveDialog.Setup(p => p.ShowDialog()).Returns(false);
            var result = _service.Show();
            Assert.That(result, Is.Null);
        }

        [Test]
        public void ShowSaveFileDialogShouldReturnFilePath()
        {
            var result = _service.Show();
            Assert.That(result, Is.EqualTo(_filePath));
        }
    }
}
