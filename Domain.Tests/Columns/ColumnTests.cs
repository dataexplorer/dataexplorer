using System.Collections.Generic;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Semantics;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Columns
{
    [TestFixture]
    public class ColumnTests
    {
        private Column _column;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder()
                .WithId(1)
                .WithIndex(0)
                .WithName("Test")
                .WithDataType(typeof(bool))
                .WithSemanticType(SemanticType.Measure)
                .WithValues(new List<object> { 0, 1000, null })
                .Build();
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

        [Test]
        public void TestGetDataTypeShouldReturnDataType()
        {
            var result = _column.DataType;
            Assert.That(result, Is.EqualTo(typeof(bool)));
        }

        [Test]
        public void TestGetSemanticTypeShouldReturnSemanticType()
        {
            var result = _column.SemanticType;
            Assert.That(result, Is.EqualTo(SemanticType.Measure));
        }

        [Test]
        public void TestHasNullsShouldReturnHasNulls()
        {
            var result = _column.HasNulls;
            Assert.That(result, Is.True);
        }
    }
}
