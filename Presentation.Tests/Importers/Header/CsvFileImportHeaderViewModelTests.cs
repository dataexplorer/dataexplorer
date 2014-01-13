using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Importers.CsvFiles;
using DataExplorer.Application.Importers.CsvFiles.Commands;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Importers.CsvFiles.Queries;
using DataExplorer.Presentation.Dialogs;
using DataExplorer.Presentation.Dialogs.Open;
using DataExplorer.Presentation.Importers.CsvFile.Header;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Importers.Header
{
    [TestFixture]
    public class CsvFileImportHeaderViewModelTests
    {
        private CsvFileImportHeaderViewModel _viewModel;
        private Mock<IMessageBus> _mockService;
        private Mock<IDialogFactory> _mockFactory;
        private Mock<IOpenFileDialog> _mockDialog;

        [SetUp]
        public void SetUp()
        {
            _mockService = new Mock<IMessageBus>();
            _mockDialog = new Mock<IOpenFileDialog>();
            _mockFactory = new Mock<IDialogFactory>();
            _viewModel = new CsvFileImportHeaderViewModel(
                _mockService.Object,
                _mockFactory.Object);
        }

        [Test]
        public void TestGetFilePathShouldReturnFilePath()
        {
            var sourceDto = new CsvFileSourceDto() {FilePath = @"C:\Test.csv" };
            _mockService.Setup(p => p.Execute(It.IsAny<GetCsvFileSourceQuery>()))
                .Returns(sourceDto);
            var result = _viewModel.FilePath;
            Assert.That(result, Is.EqualTo(@"C:\Test.csv"));
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
            _mockService.Verify(p => p.Execute(
                    It.Is<UpdateCsvFileSourceCommand>(q => q.FilePath == @"C:\Test.csv")), 
                Times.Once());
        }

        [Test]
        public void TestHandleFilePathChangedShouldUpdateBindings()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (sender, args) => { wasRaised = true; };
            _viewModel.Handle(new CsvFileSourceChangedEvent());
            Assert.That(wasRaised, Is.True);
        }
    }
}
