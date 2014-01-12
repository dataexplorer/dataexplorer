using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Domain.Columns;
using DataExplorer.Tests.Domain.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Columns.Queries
{
    [TestFixture]
    public class GetDistinctColumnValuesQueryTests
    {
        private GetDistinctColumnValuesQuery _query;
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

            _query = new GetDistinctColumnValuesQuery(
                _mockRepository.Object);
        }

        [Test]
        public void TestExecuteShouldReturnDistinctColumnValues()
        {
            var results = _query.Execute(_column.Id);
            Assert.That(results.Single(), Is.EqualTo(_value));
        }
    }
}
