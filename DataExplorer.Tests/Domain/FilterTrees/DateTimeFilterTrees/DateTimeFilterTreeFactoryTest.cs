using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.FilterTrees.DateTimeFilterTrees;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.DateTimeFilterTrees
{
    [TestFixture]
    public class DateTimeFilterTreeFactoryTest
    {
        private DateTimeFilterTreeFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new DateTimeFilterTreeFactory();
        }

        [Test]
        public void TestCreateRootShouldCreateRoot()
        {
            var column = new ColumnBuilder().WithName("Test").Build();
            var result = _factory.CreateRoot(column);
            Assert.That(result.Name, Is.EqualTo("Test"));
        }
    }
}
