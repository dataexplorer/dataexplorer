using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Application;
using DataExplorer.Infrastructure.Application;
using DataExplorer.Presentation.Dialogs;
using DataExplorer.Presentation.Dialogs.Open;
using DataExplorer.Presentation.Dialogs.Save;
using DataExplorer.Presentation.Importers.CsvFile;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Dialogs
{
    [TestFixture, RequiresSTA]
    public class DialogServiceTests
    {
        private DialogService _service;
        private Mock<IDialogFactory> _mockFactory;
        private Mock<IApplication> _mockApplication;
        private Mock<IDialog> _mockDialog;
        private Mock<IOpenFileDialog> _mockOpenDialog;
        private Mock<ISaveFileDialog> _mockSaveDialog;
        private Mock<ICsvFileImportViewModel> _mockImportCsvFileViewModel;
        private Window _mainWindow;
        private string _filePath;

        [SetUp]
        public void SetUp()
        {
            _mainWindow = new Window();
            _filePath = @"C:\Test";

            _mockDialog = new Mock<IDialog>();

            _mockOpenDialog = new Mock<IOpenFileDialog>();
            _mockOpenDialog.Setup(p => p.ShowDialog()).Returns(true);
            _mockOpenDialog.Setup(p => p.GetFilePath()).Returns(_filePath);

            _mockSaveDialog = new Mock<ISaveFileDialog>();
            _mockSaveDialog.Setup(p => p.ShowDialog()).Returns(true);
            _mockSaveDialog.Setup(p => p.GetFilePath()).Returns(_filePath);

            _mockFactory = new Mock<IDialogFactory>();
            _mockFactory.Setup(p => p.CreateImportCsvFileDialog()).Returns(_mockDialog.Object);
            _mockFactory.Setup(p => p.CreateOpenFileDialog()).Returns(_mockOpenDialog.Object);
            _mockFactory.Setup(p => p.CreateSaveFileDialog()).Returns(_mockSaveDialog.Object);

            _mockApplication = new Mock<IApplication>();
            _mockApplication.Setup(p => p.GetMainWindow()).Returns(_mainWindow);
            
            _mockImportCsvFileViewModel = new Mock<ICsvFileImportViewModel>();

            _service = new DialogService(
                _mockFactory.Object,
                _mockApplication.Object,
                _mockImportCsvFileViewModel.Object);
        }

        [Test]
        public void ShowImportDialogShouldDisplayImportDialog()
        {
            _service.ShowImportDialog();
            _mockDialog.VerifySet(p => p.DataContext = _mockImportCsvFileViewModel.Object, Times.Once());
            _mockDialog.Verify(p => p.ShowDialog(), Times.Once());
        }

        [Test]
        public void ShowOpenFileDialogShouldDisplayDialog()
        {
            _service.ShowOpenDialog();
            _mockOpenDialog.Verify(p => p.SetTitle("Open"), Times.Once());
            _mockOpenDialog.Verify(p => p.SetDefaultExtension(".xml"), Times.Once());
            _mockOpenDialog.Verify(p => p.SetFilter("Data Explorer Projects|*.xml"), Times.Once());
            _mockOpenDialog.Verify(p => p.ShowDialog(), Times.Once());
        }

        [Test]
        public void ShowOpenFileDialogShouldReturnNullIfResultIsFalse()
        {
            _mockOpenDialog.Setup(p => p.ShowDialog()).Returns(false);
            var result = _service.ShowOpenDialog();
            Assert.That(result, Is.Null);
        }

        [Test]
        public void ShowOpenFileDialogShouldReturnFilePath()
        {
            var result = _service.ShowOpenDialog();
            Assert.That(result, Is.EqualTo(_filePath));
        }

        [Test]
        public void ShowSaveFileDialogShouldDisplayDialog()
        {
            _service.ShowSaveDialog();
            _mockSaveDialog.Verify(p => p.SetTitle("Save"), Times.Once());
            _mockSaveDialog.Verify(p => p.SetDefaultExtension(".xml"), Times.Once());
            _mockSaveDialog.Verify(p => p.SetFilter("Data Explorer Projects|*.xml"), Times.Once());
            _mockSaveDialog.Verify(p => p.ShowDialog(), Times.Once());
        }

        [Test]
        public void ShowSaveFileDialogShouldReturnNullIfResultIsFalse()
        {
            _mockSaveDialog.Setup(p => p.ShowDialog()).Returns(false);
            var result = _service.ShowSaveDialog();
            Assert.That(result, Is.Null);
        }

        [Test]
        public void ShowSaveFileDialogShouldReturnFilePath()
        {
            var result = _service.ShowSaveDialog();
            Assert.That(result, Is.EqualTo(_filePath));
        }
    }
}
