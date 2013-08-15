using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.Columns
{
    [TestFixture]
    public class ColumnTests
    {
        private Column _column;

        [SetUp]
        public void SetUp()
        {
            _column = new Column(1, 0, "Test");
        }

        [Test]
        public void TestGetIdShouldReturnId()
        {
            var result = _column.Id;
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void TestGetIndexShouldReturnIndex()
        {
            var result = _column.Index;
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void TestGetNameShouldReturnName()
        {
            var result = _column.Name;
            Assert.That(result, Is.EqualTo("Test"));
        }


    }
}
