using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Importers.CsvFiles;
using DataExplorer.Application.Importers.CsvFiles.Commands;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Importers.CsvFiles.Queries;
using DataExplorer.Presentation.Importers.CsvFile;
using DataExplorer.Presentation.Importers.CsvFile.Footer;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Importers.Footer
{
    [TestFixture]
    public class CsvFileImportFooterViewModelTests
    {
        private CsvFileImportFooterViewModel _viewModel;
        private Mock<IMessageBus> _mockMessageBus;

        [SetUp]
        public void SetUp()
        {
            _mockMessageBus = new Mock<IMessageBus>();
            _viewModel = new CsvFileImportFooterViewModel(
                _mockMessageBus.Object);
        }

        [Test]
        public void TestCanImportShouldReturnIfImportState()
        {
            _mockMessageBus.Setup(p => p.Execute(It.IsAny<CanImportQuery>()))
                .Returns(true);
            var result = _viewModel.ImportCommand.CanExecute(null);
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestImportShouldImportData()
        {
            _viewModel.ImportCommand.Execute(null);
            _mockMessageBus.Verify(p => p.Execute(
                    It.IsAny<ImportCsvFileSourceCommand>()), 
                Times.Once());
        }

        [Test]
        public void TestCanceShouldCloseDialog()
        {
            var wasRaised = false;
            _viewModel.DialogClosed += (s, e) => { wasRaised = true; };
            _viewModel.CancelCommand.Execute(null);
            Assert.That(wasRaised, Is.True);
        }

        [Test]
        public void TestHandleFilePathChangedShouldUpdateCanImport()
        {
            var wasRaised = false;
            _viewModel.ImportCommand.CanExecuteChanged += (s, e) => { wasRaised = true; };
            _viewModel.Handle(new CsvFileSourceChangedEvent());
            Assert.That(wasRaised, Is.True);
        }

        [Test]
        public void TestHandleDataImportingShouldUpdateIsProgressBarVisible()
        {
            _viewModel.Handle(new CsvFileImportingEvent());
            Assert.That(_viewModel.IsProgressBarVisible, Is.True);
        }

        [Test]
        public void TestHandleDataImportingShouldSetProgressToZero()
        {
            _viewModel.Handle(new CsvFileImportingEvent());
            Assert.That(_viewModel.Progress, Is.EqualTo(0));
        }

        [Test]
        public void TestHandleDataImportingShouldNotifyIsProgressBarVisibleChanged()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) => { wasRaised = (e.PropertyName == "IsProgressBarVisible"); };
            _viewModel.Handle(new CsvFileImportingEvent());
        }

        [Test]
        public void TestHandleDataImportingShouldNotifyProgressChanged()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) => { wasRaised = (e.PropertyName == "Progress"); };
            _viewModel.Handle(new CsvFileImportingEvent());
        }

        [Test]
        public void TestHandlDataImportedShouldUpdateIsProgressBarVisible()
        {
            _viewModel.Handle(new CsvFileImportedEvent());
            Assert.That(_viewModel.IsProgressBarVisible, Is.False);
        }

        [Test]
        public void TestHandleDataImportedShouldSetProgressToZero()
        {
            _viewModel.Handle(new CsvFileImportedEvent());
            Assert.That(_viewModel.Progress, Is.EqualTo(0));
        }

        [Test]
        public void TestHandlDataImportedShouldNotifyIsProgressBarVisibleChanged()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) =>
            { if (e.PropertyName == "IsProgressBarVisible") wasRaised = true; };
            _viewModel.Handle(new CsvFileImportedEvent());
            Assert.That(wasRaised, Is.True);
        }

        [Test]
        public void TestHandleDataImportedShouldNotifyProgressChanged()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) => { wasRaised = (e.PropertyName == "Progress"); };
            _viewModel.Handle(new CsvFileImportedEvent());
        }

        [Test]
        public void TestHandleDataImportedShouldCloseTheDialog()
        {
            var wasRaised = false;
            _viewModel.DialogClosed += (s, e) => { wasRaised = true; };
            _viewModel.Handle(new CsvFileImportedEvent());
            Assert.That(wasRaised, Is.True);
        }

        [Test]
        public void TestHandleDataImportProgressChangedShouldUpdateProgress()
        {
            _viewModel.Handle(new CsvFileImportProgressChangedEvent(50));
            Assert.That(_viewModel.Progress, Is.EqualTo(50));
        }

        [Test]
        public void TestHandleDataImportProgressChangedShouldNotifyProgressChanged()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) => { wasRaised = (e.PropertyName == "Progress"); };
            _viewModel.Handle(new CsvFileImportProgressChangedEvent(50));
            Assert.That(wasRaised, Is.True);
        }
    }
}
