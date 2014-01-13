using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Rows.Queries;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Tests.Rows;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Rows.Queries
{
    [TestFixture]
    public class GetLastSelectedRowQueryHandlerTests
    {
        private GetLastSelectedRowQueryHandler _handler;
        private Mock<IApplicationStateService> _mockStateService;
        private List<Row> _rows;
        private Row _firstRow;
        private Row _lastRow;

        [SetUp]
        public void SetUp()
        {
            _firstRow = new RowBuilder().Build();
            _lastRow  = new RowBuilder().Build();
            _rows = new List<Row> { _firstRow, _lastRow };
            
            _mockStateService = new Mock<IApplicationStateService>();
            _mockStateService.Setup(p => p.GetSelectedRows()).Returns(_rows);

            _handler = new GetLastSelectedRowQueryHandler(
                _mockStateService.Object);
        }

        [Test]
        public void TestExecuteShouldReturnNullIfNoRowsAreSelected()
        {
            _rows.Clear();
            var result = _handler.Execute(new GetLastSelectedRowQuery());
            Assert.That(result, Is.Null);
        }

        [Test]
        public void TestExecuteShouldReturnLastSelectedRowFromStateService()
        {
            var result = _handler.Execute(new GetLastSelectedRowQuery());
            Assert.That(result, Is.EqualTo(_lastRow));
        }
    }
}
