using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Persistence.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Persistence.Columns
{
    [TestFixture]
    public class ColumnRepositoryTests
    {
        private ColumnRepository _repository;
        private Mock<IColumnContext> _mockContext;
        private List<Column> _columns;
        
        [SetUp]
        public void SetUp()
        {
            _columns = new List<Column>();
            _mockContext = new Mock<IColumnContext>();
            _mockContext.Setup(p => p.Columns).Returns(_columns);
            _repository = new ColumnRepository(_mockContext.Object);
        }

        [Test]
        public void TestGetAllShouldReturnColumns()
        {
            var column = new Column(1, "Column 1");
            _columns.Add(column);
            var result = _repository.GetAll();
            Assert.That(result.Single(), Is.EqualTo(column));
        }

        [Test]
        public void TestAddShouldAddColumn()
        {
            var column = new Column(1, "Column 1");
            _repository.Add(column);
            Assert.That(_columns.Single(), Is.EqualTo(column));
        }
    }
}
