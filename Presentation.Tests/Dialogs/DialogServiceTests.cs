using System;
using System.Drawing;
using System.Windows;
using DataExplorer.Presentation.Dialogs;
using DataExplorer.Presentation.Dialogs.Import;
using DataExplorer.Presentation.Dialogs.Open;
using DataExplorer.Presentation.Dialogs.Save;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Dialogs
{
    [TestFixture, RequiresSTA]
    public class DialogServiceTests
    {
        private DialogService _service;
        private Mock<IImportDialogService> _mockImportService;
        private Mock<IOpenDialogService> _mockOpenService;
        private Mock<ISaveDialogService> _mockSaveService;
        private Mock<IExceptionDialogService> _mockExceptionService;

        [SetUp]
        public void SetUp()
        {
            _mockImportService = new Mock<IImportDialogService>();
            _mockOpenService = new Mock<IOpenDialogService>();
            _mockSaveService = new Mock<ISaveDialogService>();
            _mockExceptionService = new Mock<IExceptionDialogService>();
            
            _service = new DialogService(
                _mockImportService.Object,
                _mockOpenService.Object,
                _mockSaveService.Object,
                _mockExceptionService.Object);
        }

        [Test]
        public void ShowImportDialogShouldDisplayImportDialog()
        {
            _service.ShowImportDialog();
            _mockImportService.Verify(p => p.Show(), Times.Once());
        }

        [Test]
        public void ShowOpenFileDialogShouldDisplayDialog()
        {
            _service.ShowOpenDialog();
            _mockOpenService.Verify(p => p.Show(), Times.Once());
        }
        
        [Test]
        public void ShowSaveFileDialogShouldDisplayDialog()
        {
            _service.ShowSaveDialog();
            _mockSaveService.Verify(p => p.Show());
        }

        [Test]
        public void TestShowExceptionDialogShouldShowDialog()
        {
            var ex = new Exception();
            _service.ShowExceptionDialog(ex);
            _mockExceptionService.Verify(p => p.Show(ex));
        }
    }
}
