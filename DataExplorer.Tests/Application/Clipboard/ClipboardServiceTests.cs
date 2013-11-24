using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Clipboard;
using DataExplorer.Application.Clipboard.Commands;
using DataExplorer.Application.Clipboard.Queries;
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
        private Mock<ICanCopyDataToClipboardQuery> _mockCanCopyDataQuery;
        private Mock<ICopyDataToClipboardCommand> _mockCopyDataCommand;

        [SetUp]
        public void SetUp()
        {
            _mockCanCopyDataQuery = new Mock<ICanCopyDataToClipboardQuery>();
            _mockCopyDataCommand = new Mock<ICopyDataToClipboardCommand>();

            _service = new ClipboardService(
                _mockCanCopyDataQuery.Object,
                _mockCopyDataCommand.Object);
        }

        [Test]
        public void TestCanCopyShouldExecuteCanCopyDataToClipboardQuery()
        {
            _mockCanCopyDataQuery.Setup(p => p.Execute()).Returns(true);
            var result = _service.CanCopy();
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestCopyShouldCopyDataToClipboard()
        {
            _service.Copy();
            _mockCopyDataCommand.Verify(p => p.Execute(), Times.Once());
        }
    }
}
