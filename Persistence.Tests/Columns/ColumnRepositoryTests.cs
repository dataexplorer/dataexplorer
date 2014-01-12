using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Persistence.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Persistence.Tests.Columns
{
    [TestFixture]
    public class ColumnRepositoryTests
    {
        private ColumnRepository _repository;
        private Mock<IDataContext> _mockContext;
        private List<Column> _columns;
        
        [SetUp]
        public void SetUp()
        {
            _columns = new List<Column>();
            _mockContext = new Mock<IDataContext>();
            _mockContext.Setup(p => p.Columns).Returns(_columns);
            _repository = new ColumnRepository(_mockContext.Object);
        }

        [Test]
        public void TestGetAllShouldReturnColumns()
        {
            var column = new ColumnBuilder().Build();
            _columns.Add(column);
            var result = _repository.GetAll();
            Assert.That(result.Single(), Is.EqualTo(column));
        }

        [Test]
        public void TestGetShouldReturnColumn()
        {
            var column = new ColumnBuilder().WithId(1).Build();
            _columns.Add(column);
            var result = _repository.Get(1);
            Assert.That(result, Is.EqualTo(column));
        }

        [Test]
        public void TestAddShouldAddColumn()
        {
            var column = new ColumnBuilder().Build();
            _repository.Add(column);
            Assert.That(_columns.Single(), Is.EqualTo(column));
        }
    }
}
