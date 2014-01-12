using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Tests.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Columns.Queries
{
    [TestFixture]
    public class GetAllColumnsQueryTests
    {
        private GetAllColumnsQuery _query;
        private Mock<IColumnRepository> _mockRepository;
        private Mock<IColumnAdapter> _mockAdapter;
        private List<Column> _columns;
        private Column _column;
        private ColumnDto _columnDto;

        [SetUp]
        public void SetUp()
        {
            _columnDto = new ColumnDto();
            _column = new ColumnBuilder().Build();
            _columns = new List<Column> { _column };

            _mockRepository = new Mock<IColumnRepository>();
            _mockRepository.Setup(p => p.GetAll()).Returns(_columns);

            _mockAdapter = new Mock<IColumnAdapter>();
            _mockAdapter.Setup(p => p.Adapt(_column)).Returns(_columnDto);

            _query = new GetAllColumnsQuery(
                _mockRepository.Object,
                _mockAdapter.Object);
        }

        [Test]
        public void TestQueryShouldReturnAllColumns()
        {
            var result = _query.Query();
            Assert.That(result.Single(), Is.EqualTo(_columnDto));
        }
    }
}
