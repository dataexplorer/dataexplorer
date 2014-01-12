using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Tests.Rows;
using DataExplorer.Persistence.Rows;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Persistence.Tests.Rows
{
    [TestFixture]
    public class RowRepositoryTests
    {
        private RowRepository _repository;
        private Mock<IDataContext> _mockDataContext;
        private List<Row> _rows;

        [SetUp]
        public void SetUp()
        {
            _rows = new List<Row>();
            _mockDataContext = new Mock<IDataContext>();
            _mockDataContext.SetupGet(p => p.Rows).Returns(_rows);
            _repository = new RowRepository(_mockDataContext.Object);
        }

        [Test]
        public void TestGetAllReturnsAllDataRows()
        {
            var row = new RowBuilder().Build();
            _rows.Add(row);
            var result = _repository.GetAll();
            Assert.That(result.Single(), Is.EqualTo(_rows.Single()));
        }

        [Test]
        public void TestAddShouldAddARow()
        {
            var row = new RowBuilder().Build();
            _repository.Add(row);
            Assert.That(_rows.Single(), Is.EqualTo(row));
        }
    }


}
