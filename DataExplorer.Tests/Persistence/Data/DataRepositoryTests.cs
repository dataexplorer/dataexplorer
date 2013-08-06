using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Persistence.Data;
using DataExplorer.Tests.Domain;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Persistence.Data
{
    [TestFixture]
    public class DataRepositoryTests
    {
        private DataRepository _repository;
        private Mock<IDataContext> _mockDataContext;

        [SetUp]
        public void SetUp()
        {
            _mockDataContext = new Mock<IDataContext>();
            _repository = new DataRepository(_mockDataContext.Object);
        }

        [Test]
        public void TestGetAllReturnsAllDataRows()
        {
            var dataRows = new DataRowBuilder().BuildList();
            _mockDataContext.SetupGet(p => p.DataRows).Returns(dataRows);
            var result = _repository.GetAll();
            Assert.That(result.Single(), Is.EqualTo(dataRows.Single()));
        }
    }


}
