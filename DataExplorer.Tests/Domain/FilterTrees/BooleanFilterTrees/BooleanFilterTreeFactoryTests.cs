using System;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.BooleanFilterTrees;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.BooleanFilterTrees
{
    [TestFixture]
    public class BooleanFilterTreeFactoryTests
    {
        private BooleanFilterTreeFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new BooleanFilterTreeFactory();
        }

        [Test]
        public void TestCreateRootShouldCreateRoot()
        {
            var column = new ColumnBuilder().WithName("Test").Build();
            var result = _factory.CreateRoot(column);
            Assert.That(result.Name, Is.EqualTo("Test"));
        }

        [Test]
        public void TestCreateChildrenShouldCreateChildren()
        {
            Assert.Inconclusive();
        }
    }
}
