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
        private Row _row;

        [SetUp]
        public void SetUp()
        {
            _row = new RowBuilder()
                .WithId(1)
                .Build();
            _rows = new List<Row> { _row };
            
            _mockDataContext = new Mock<IDataContext>();
            _mockDataContext.SetupGet(p => p.Rows).Returns(_rows);

            _repository = new RowRepository(_mockDataContext.Object);
        }

        [Test]
        public void TestGetAllReturnsAllDataRows()
        {
            var result = _repository.GetAll();
            Assert.That(result.Single(), Is.EqualTo(_rows.Single()));
        }

        [Test]
        public void TestGetShouldReturnRow()
        {
            var result = _repository.Get(_row.Id);
            Assert.That(result, Is.EqualTo(_row));
        }

        [Test]
        public void TestAddShouldAddARow()
        {
            _rows.Clear();
            _repository.Add(_row);
            Assert.That(_rows.Single(), Is.EqualTo(_row));
        }
    }


}
