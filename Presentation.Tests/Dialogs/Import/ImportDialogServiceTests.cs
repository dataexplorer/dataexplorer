using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Application;
using DataExplorer.Presentation.Dialogs;
using DataExplorer.Presentation.Dialogs.Import;
using DataExplorer.Presentation.Importers.CsvFile;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Dialogs.Import
{
    [TestFixture, RequiresSTA]
    public class ImportDialogServiceTests
    {
        private ImportDialogService _service;
        private Mock<IDialogFactory> _mockFactory;
        private Mock<IApplication> _mockApplication;
        private Mock<IDialog> _mockDialog;
        private Mock<ICsvFileImportViewModel> _mockImportCsvFileViewModel;
        private Window _mainWindow;

        [SetUp]
        public void SetUp()
        {
            _mainWindow = new Window();

            _mockDialog = new Mock<IDialog>();

            _mockFactory = new Mock<IDialogFactory>();
            _mockFactory.Setup(p => p.CreateImportCsvFileDialog())
                .Returns(_mockDialog.Object);

            _mockApplication = new Mock<IApplication>();
            _mockApplication.Setup(p => p.GetMainWindow())
                .Returns(_mainWindow);

            _mockImportCsvFileViewModel = new Mock<ICsvFileImportViewModel>();

            _service = new ImportDialogService(
                _mockFactory.Object,
                _mockApplication.Object,
                _mockImportCsvFileViewModel.Object);
        }

        [Test]
        public void ShowImportDialogShouldDisplayImportDialog()
        {
            _service.Show();
            _mockDialog.VerifySet(p => p.DataContext = _mockImportCsvFileViewModel.Object, Times.Once());
            _mockDialog.Verify(p => p.ShowDialog(), Times.Once());
        }
    }
}
