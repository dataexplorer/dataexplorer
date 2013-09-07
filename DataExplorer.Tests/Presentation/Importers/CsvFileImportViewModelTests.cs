﻿using System;
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
        public void TestCanImportShouldReturnIfImportState()
        {
            _mockService.Setup(p => p.CanImport()).Returns(true);
            var result = _viewModel.ImportCommand.CanExecute(null);
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestImportShouldImportData()
        {
            _viewModel.ImportCommand.Execute(null);
            _mockService.Verify(p => p.Import(), Times.Once());
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
        public void TestHandleFilePathChangedShouldUpdateBindings()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (sender, args) => { wasRaised = true; };
            _mockService.Raise(p => p.FilePathChanged += null, this, EventArgs.Empty);
            Assert.That(wasRaised, Is.True);
        }

        [Test]
        public void TestHandleFilePathChangedShouldUpdateCanImport()
        {
            var wasRaised = false;
            _viewModel.ImportCommand.CanExecuteChanged += (s, e) => { wasRaised = true; };
            _mockService.Raise(p => p.FilePathChanged += null, this, EventArgs.Empty);
            Assert.That(wasRaised, Is.True);
        }

        [Test]
        public void TestHandleDataImportingShouldUpdateIsProgressBarVisible()
        {
            _mockService.Raise(p => p.DataImporting += null, this, EventArgs.Empty);
            Assert.That(_viewModel.IsProgressBarVisible, Is.True);
        }

        [Test]
        public void TestHandleDataImportingShouldSetProgressToZero()
        {
            _mockService.Raise(p => p.DataImporting += null, this, EventArgs.Empty);
            Assert.That(_viewModel.Progress, Is.EqualTo(0));
        }

        [Test]
        public void TestHandleDataImportingShouldNotifyIsProgressBarVisibleChanged()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) => { wasRaised = (e.PropertyName == "IsProgressBarVisible"); };
            _mockService.Raise(p => p.DataImporting += null, this, EventArgs.Empty);
        }

        [Test]
        public void TestHandleDataImportingShouldNotifyProgressChanged()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) => { wasRaised = (e.PropertyName == "Progress"); };
            _mockService.Raise(p => p.DataImporting += null, this, EventArgs.Empty);
        }

        [Test]
        public void TestHandlDataImportedShouldUpdateIsProgressBarVisible()
        {
            _mockService.Raise(p => p.DataImported += null, this, EventArgs.Empty);
            Assert.That(_viewModel.IsProgressBarVisible, Is.False);
        }

        [Test]
        public void TestHandleDataImportedShouldSetProgressToZero()
        {
            _mockService.Raise(p => p.DataImported += null, this, EventArgs.Empty);
            Assert.That(_viewModel.Progress, Is.EqualTo(0));
        }

        [Test]
        public void TestHandlDataImportedShouldNotifyIsProgressBarVisibleChanged()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) => 
                { if (e.PropertyName == "IsProgressBarVisible") wasRaised = true; };
            _mockService.Raise(p => p.DataImported += null, this, EventArgs.Empty);
            Assert.That(wasRaised, Is.True);
        }

        [Test]
        public void TestHandleDataImportedShouldNotifyProgressChanged()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) => { wasRaised = (e.PropertyName == "Progress"); };
            _mockService.Raise(p => p.DataImported += null, this, EventArgs.Empty);
        }

        [Test]
        public void TestHandleDataImportedShouldCloseTheDialog()
        {
            var wasRaised = false;
            _viewModel.DialogClosed += (s, e) => { wasRaised = true; };
            _mockService.Raise(p => p.DataImported += null, this, EventArgs.Empty);
            Assert.That(wasRaised, Is.True);
        }

        [Test]
        public void TestHandleDataImportProgressChangedShouldUpdateProgress()
        {
            var args = new DataImportProgressChangedEventArgs(50);
            _mockService.Raise(p => p.DataImportProgressChanged += null, this, args);
            Assert.That(_viewModel.Progress, Is.EqualTo(50));
        }


        [Test]
        public void TestHandleDataImportProgressChangedShouldNotifyProgressChanged()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) => { wasRaised = (e.PropertyName == "Progress"); };
            var args = new DataImportProgressChangedEventArgs(50);
            _mockService.Raise(p => p.DataImportProgressChanged += null, this, args);
            Assert.That(wasRaised, Is.True);
        }

        //[Test]
        //public void TestIsProgressBarVisibleShouldReturnIsImporting()
        //{
        //    _mockService.Setup(p => p.IsImporting()).Returns(true);
        //    var result = _viewModel.IsProgressBarVisible;
        //    Assert.That(result, Is.True);
        //}
    }
}
