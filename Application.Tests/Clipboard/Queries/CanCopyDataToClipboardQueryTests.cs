using System.Collections.Generic;
using DataExplorer.Application.Application;
using DataExplorer.Application.Clipboard.Queries;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Tests.Rows;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Clipboard.Queries
{
    [TestFixture]
    public class CanCopyDataToClipboardQueryTests
    {
        private CanCopyDataToClipboardQuery _query;
        private Mock<IApplicationStateService> _mockService;
        private List<Row> _rows;
        private Row _row;

        [SetUp]
        public void SetUp()
        {
            _row = new RowBuilder().Build();
            _rows = new List<Row> { _row };
         
            _mockService = new Mock<IApplicationStateService>();
            _mockService.Setup(p => p.GetSelectedRows()).Returns(_rows);

            _query = new CanCopyDataToClipboardQuery(
                _mockService.Object);
        }

        [Test]
        public void TestExecuteShouldReturnTrueIfRowsAreSelected()
        {
            var result = _query.Execute();
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestExecuteShouldReturnFalseIfNoRowsAreSelected()
        {
            _rows.Clear();
            var result = _query.Execute();
            Assert.That(result, Is.False);
        }
    }
}
