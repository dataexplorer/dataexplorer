using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Importers.CsvFiles.Commands;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Importers.CsvFiles.Queries;
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
        public void TestHandleSourceImportingShouldUpdateIsProgressBarVisible()
        {
            _viewModel.Handle(new SourceImportingEvent());
            Assert.That(_viewModel.IsProgressBarVisible, Is.True);
        }

        [Test]
        public void TestHandleSourceImportingShouldSetProgressToZero()
        {
            _viewModel.Handle(new SourceImportingEvent());
            Assert.That(_viewModel.Progress, Is.EqualTo(0));
        }

        [Test]
        public void TestHandleSourceImportingShouldNotifyIsProgressBarVisibleChanged()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) => { wasRaised = (e.PropertyName == "IsProgressBarVisible"); };
            _viewModel.Handle(new SourceImportingEvent());
        }

        [Test]
        public void TestHandleSourceImportingShouldNotifyProgressChanged()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) => { wasRaised = (e.PropertyName == "Progress"); };
            _viewModel.Handle(new SourceImportingEvent());
        }

        [Test]
        public void TestHandleSourceImportedShouldUpdateIsProgressBarVisible()
        {
            _viewModel.Handle(new SourceImportedEvent());
            Assert.That(_viewModel.IsProgressBarVisible, Is.False);
        }

        [Test]
        public void TestHandleSourceImportedShouldSetProgressToZero()
        {
            _viewModel.Handle(new SourceImportedEvent());
            Assert.That(_viewModel.Progress, Is.EqualTo(0));
        }

        [Test]
        public void TestHandleSourceImportedShouldNotifyIsProgressBarVisibleChanged()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) =>
            { if (e.PropertyName == "IsProgressBarVisible") wasRaised = true; };
            _viewModel.Handle(new SourceImportedEvent());
            Assert.That(wasRaised, Is.True);
        }

        [Test]
        public void TestHandleSourceImportedShouldNotifyProgressChanged()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) => { wasRaised = (e.PropertyName == "Progress"); };
            _viewModel.Handle(new SourceImportedEvent());
        }

        [Test]
        public void TestHandleSourceImportedShouldCloseTheDialog()
        {
            var wasRaised = false;
            _viewModel.DialogClosed += (s, e) => { wasRaised = true; };
            _viewModel.Handle(new SourceImportedEvent());
            Assert.That(wasRaised, Is.True);
        }

        [Test]
        public void TestHandleSourceImportProgressChangedShouldUpdateProgress()
        {
            _viewModel.Handle(new SourceImportProgressChangedEvent(50));
            Assert.That(_viewModel.Progress, Is.EqualTo(50));
        }

        [Test]
        public void TestHandleSourceImportProgressChangedShouldNotifyProgressChanged()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) => { wasRaised = (e.PropertyName == "Progress"); };
            _viewModel.Handle(new SourceImportProgressChangedEvent(50));
            Assert.That(wasRaised, Is.True);
        }
    }
}
