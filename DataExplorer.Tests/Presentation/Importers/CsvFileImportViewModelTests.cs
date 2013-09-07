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
        private Mock<ICsvFileImportHeaderViewModel> _mockHeader;
        private Mock<ICsvFileImportFooterViewModel> _mockFooter;
        
        [SetUp]
        public void SetUp()
        {
            _mockHeader = new Mock<ICsvFileImportHeaderViewModel>();
            _mockFooter = new Mock<ICsvFileImportFooterViewModel>();
            _viewModel = new CsvFileImportViewModel(
                _mockHeader.Object,
                _mockFooter.Object);
        }

        [Test]
        public void TestGetHeaderShouldReturnHeader()
        {
            var result = _viewModel.HeaderViewModel;
            Assert.That(result, Is.EqualTo(_mockHeader.Object));
        }

        [Test]
        public void TestGetFooterShouldReturnFooter()
        {
            var result = _viewModel.FooterViewModel;
            Assert.That(result, Is.EqualTo(_mockFooter.Object));
        }
    }
}
