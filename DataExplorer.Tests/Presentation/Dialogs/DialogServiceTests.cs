using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Application;
using DataExplorer.Infrastructure.Application;
using DataExplorer.Presentation.Dialogs;
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
        private Mock<ICsvFileImportViewModel> _mockImportCsvFileViewModel;

        [SetUp]
        public void SetUp()
        {
            _mockDialog = new Mock<IDialog>();
            _mockFactory = new Mock<IDialogFactory>();
            _mockApplication = new Mock<IApplication>();
            _mockImportCsvFileViewModel = new Mock<ICsvFileImportViewModel>();
            _service = new DialogService(
                _mockFactory.Object,
                _mockApplication.Object,
                _mockImportCsvFileViewModel.Object);
        }

        [Test]
        public void ShowImportDialogShouldDisplayImportDialog()
        {
            _mockFactory.Setup(p => p.CreateImportCsvFileDialog()).Returns(_mockDialog.Object);
            _service.ShowImportDialog();
            _mockDialog.VerifySet(p => p.DataContext = _mockImportCsvFileViewModel.Object, Times.Once());
            _mockDialog.Verify(p => p.ShowDialog(), Times.Once());
        }
    }
}
