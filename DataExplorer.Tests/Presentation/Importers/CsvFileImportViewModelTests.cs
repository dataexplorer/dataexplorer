using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Importers.CsvFile;
using DataExplorer.Presentation.Dialogs;
using DataExplorer.Presentation.Importers.CsvFile;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Importers
{
    [TestFixture]
    public class CsvFileImportViewModelTests
    {
        private CsvFileImportViewModel _viewModel;
        private Mock<ICsvFileImportService> _mockService;
        private Mock<IDialogFactory> _mockFactory;
        private Mock<IOpenFileDialog> _mockDialog;

        [SetUp]
        public void SetUp()
        {
            _mockService = new Mock<ICsvFileImportService>();
            _mockDialog = new Mock<IOpenFileDialog>();
            _mockFactory = new Mock<IDialogFactory>();
            _viewModel = new CsvFileImportViewModel(
                _mockService.Object,
                _mockFactory.Object);
        }

        [Test]
        public void TestBrowseShouldShowOpenFileDialog()
        {
            _mockFactory.Setup(p => p.CreateOpenFileDialog()).Returns(_mockDialog.Object);
            _viewModel.BrowseCommand.Execute(null);
            _mockDialog.Verify(p => p.SetDefaultExtension(".csv"), Times.Once());
            _mockDialog.Verify(p => p.SetFilter("CSV documents|*.csv"), Times.Once());
            _mockDialog.Verify(p => p.ShowDialog(), Times.Once());
        }

        [Test]
        public void TestBrowseShouldSetFilePathIfSpecified()
        {
            _mockFactory.Setup(p => p.CreateOpenFileDialog()).Returns(_mockDialog.Object);
            _mockDialog.Setup(p => p.ShowDialog()).Returns(true);
            _mockDialog.Setup(p => p.GetFilePath()).Returns(@"C:\Test.csv");
            _viewModel.BrowseCommand.Execute(null);
            _mockService.Verify(p => p.SetFilePath(@"C:\Test.csv"));
        }

        [Test]
        public void TestHandleFilePathChangedShouldUpdateBindings()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (sender, args) => { wasRaised = true; };
            _mockService.Raise(p => p.FilePathChanged += null, this, EventArgs.Empty);
            Assert.That(wasRaised, Is.True);
        }
    }
}
