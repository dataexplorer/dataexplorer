using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Clipboard;
using DataExplorer.Application.Exporters;
using DataExplorer.Application.Exporters.TabFile;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;
using DataExplorer.Infrastructure.Clipboard;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Clipboard
{
    [TestFixture]
    public class ClipboardServiceTests
    {
        private ClipboardService _service;
        private Mock<IColumnRepository> _mockColumnRepository;
        private Mock<IApplicationStateService> _mockStateService;
        private Mock<ITabExporter> _mockTabExporter;
        private Mock<IClipboard> _mockClipboard;
        private List<Column> _columns;
        private List<Row> _rows;
        private string _text;

        [SetUp]
        public void SetUp()
        {
            _columns = new List<Column>();
            _rows = new List<Row>();
            _text = "Test";

            _mockColumnRepository = new Mock<IColumnRepository>();
            _mockColumnRepository.Setup(p => p.GetAll()).Returns(_columns);

            _mockStateService = new Mock<IApplicationStateService>();
            _mockStateService.Setup(p => p.SelectedRows).Returns(_rows);

            _mockTabExporter = new Mock<ITabExporter>();
            _mockTabExporter.Setup(p => p.Export(_columns, _rows)).Returns(_text);

            _mockClipboard = new Mock<IClipboard>();

            _service = new ClipboardService(
                _mockColumnRepository.Object,
                _mockStateService.Object,
                _mockTabExporter.Object,
                _mockClipboard.Object);
        }

        [Test]
        public void TestCopyShouldCopyDataToClipboard()
        {
            _service.Copy();
            _mockClipboard.Verify(p => p.SetText(_text));
        }
    }
}
