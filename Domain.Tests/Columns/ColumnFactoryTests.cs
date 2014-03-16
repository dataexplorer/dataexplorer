using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Semantics;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Columns
{
    [TestFixture]
    public class ColumnFactoryTests
    {
        private ColumnFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new ColumnFactory();
        }

        [Test]
        public void TestCreateShouldCreateNewColumn()
        {
            var result = _factory.Create(1, 0, "Test", typeof(Boolean), SemanticType.Measure, new List<object>{ true });
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Index, Is.EqualTo(0));
            Assert.That(result.Name, Is.EqualTo("Test"));
            Assert.That(result.DataType, Is.EqualTo(typeof(Boolean)));
            Assert.That(result.SemanticType, Is.EqualTo(SemanticType.Measure));
            Assert.That(result.Values, Has.Member(true));
        }
    }
}
