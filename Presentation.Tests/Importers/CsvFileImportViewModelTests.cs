using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Importers.CsvFile;
using DataExplorer.Presentation.Importers.CsvFile.Body;
using DataExplorer.Presentation.Importers.CsvFile.Footer;
using DataExplorer.Presentation.Importers.CsvFile.Header;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Importers
{
    [TestFixture]
    public class CsvFileImportViewModelTests
    {
        private CsvFileImportViewModel _viewModel;
        private Mock<ICsvFileImportHeaderViewModel> _mockHeader;
        private Mock<ICsvFileImportBodyViewModel> _mockBody;
        private Mock<ICsvFileImportFooterViewModel> _mockFooter;
        
        [SetUp]
        public void SetUp()
        {
            _mockHeader = new Mock<ICsvFileImportHeaderViewModel>();
            _mockBody = new Mock<ICsvFileImportBodyViewModel>();
            _mockFooter = new Mock<ICsvFileImportFooterViewModel>();
            _viewModel = new CsvFileImportViewModel(
                _mockHeader.Object,
                _mockBody.Object,
                _mockFooter.Object);
        }

        [Test]
        public void TestGetHeaderShouldReturnHeader()
        {
            var result = _viewModel.HeaderViewModel;
            Assert.That(result, Is.EqualTo(_mockHeader.Object));
        }

        [Test]
        public void TestGetBodyShouldReturnBody()
        {
            var result = _viewModel.BodyViewModel;
            Assert.That(result, Is.EqualTo(_mockBody.Object));
        }

        [Test]
        public void TestGetFooterShouldReturnFooter()
        {
            var result = _viewModel.FooterViewModel;
            Assert.That(result, Is.EqualTo(_mockFooter.Object));
        }
    }
}
