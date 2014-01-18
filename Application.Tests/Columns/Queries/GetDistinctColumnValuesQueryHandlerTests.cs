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
    public class GetDistinctColumnValuesQueryHandlerTests
    {
        private GetDistinctColumnValuesQueryHandler _handler;
        private Mock<IColumnRepository> _mockRepository;
        private Column _column;
        private object _value;

        [SetUp]
        public void SetUp()
        {
            _value = "test";
            _column = new ColumnBuilder().WithId(1).WithValue(_value).Build();

            _mockRepository = new Mock<IColumnRepository>();
            _mockRepository.Setup(p => p.Get(_column.Id)).Returns(_column);

            _handler = new GetDistinctColumnValuesQueryHandler(
                _mockRepository.Object);
        }

        [Test]
        public void TestExecuteShouldReturnDistinctColumnValues()
        {
            var results = _handler.Execute(new GetDistinctColumnValuesQuery(_column.Id));
            Assert.That(results.Single(), Is.EqualTo(_value));
        }
    }
}
