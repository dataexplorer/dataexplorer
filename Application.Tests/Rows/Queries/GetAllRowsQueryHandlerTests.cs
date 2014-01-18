using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Rows;
using DataExplorer.Application.Rows.Queries;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Tests.Rows;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Rows.Queries
{
    [TestFixture]
    public class GetAllRowsQueryHandlerTests
    {
        private GetAllRowsQueryHandler _handler;
        private Mock<IRowRepository> _mockRepository;
        private List<Row> _rows;
        private Row _row;
            
        [SetUp]
        public void SetUp()
        {
            _row = new RowBuilder().Build();
            _rows = new List<Row> { _row };

            _mockRepository = new Mock<IRowRepository>();
            _mockRepository.Setup(p => p.GetAll()).Returns(_rows);

            _handler = new GetAllRowsQueryHandler(
                _mockRepository.Object);
        }

        [Test]
        public void TestExecuteShouldReturnAllRows()
        {
            var results = _handler.Execute(new GetAllRowsQuery());
            Assert.That(results.Single(), Is.EqualTo(_row));
        }
    }
}
