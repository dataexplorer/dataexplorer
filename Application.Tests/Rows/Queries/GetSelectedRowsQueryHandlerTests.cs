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
    public class GetSelectedRowsQueryHandlerTests
    {
        private GetSelectedRowsQueryHandler _handler;
        private Mock<IApplicationStateService> _mockStateService;
        private List<Row> _rows;
        private Row _row;
    
        [SetUp]
        public void SetUp()
        {
            _row = new RowBuilder().Build();
            _rows = new List<Row> { _row };
            
            _mockStateService = new Mock<IApplicationStateService>();
            _mockStateService.Setup(p => p.GetSelectedRows()).Returns(_rows);

            _handler = new GetSelectedRowsQueryHandler( _mockStateService.Object);
        }

        [Test]
        public void TestExecuteShouldReturnSelectedRowsFromStateService()
        {
            var results = _handler.Execute(new GetSelectedRowsQuery());
            Assert.That(results.Single(), Is.EqualTo(_row));
        }
    }
}
