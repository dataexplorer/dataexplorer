using System;
using System.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.BooleanFilterTrees;
using DataExplorer.Tests.Domain.Columns;
using DataExplorer.Tests.Presentation.Panes.Navigation.NavigationTree;
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
        public void TestCreateChildrenShouldCreateFalseLeaf()
        {
            var column = new ColumnBuilder().Build();
            var root = new BooleanFilterTreeRoot(string.Empty, column);
            var results = _factory.CreateChildren(root).ToList();
            Assert.That(results[0].Name, Is.EqualTo("False"));
        }

        [Test]
        public void TestCreateChildrenShouldCreateTrueLeaf()
        {
            var column = new ColumnBuilder().Build();
            var root = new BooleanFilterTreeRoot(string.Empty, column);
            var results = _factory.CreateChildren(root).ToList();
            Assert.That(results[1].Name, Is.EqualTo("True"));
        }

        [Test]
        public void TestCreateChildrenShouldNotCreateNullLeafIfColumnHasNoNulls()
        {
            var column = new ColumnBuilder().Build();
            var root = new BooleanFilterTreeRoot(string.Empty, column);
            var results = _factory.CreateChildren(root).ToList();
            Assert.That(results[0].Name, Is.Not.EqualTo("Null"));
        }

        [Test]
        public void TestCreateChildrenShouldCreateNullLeafIfColumnHasNulls()
        {
            var column = new ColumnBuilder().WithNulls().Build();
            var root = new BooleanFilterTreeRoot(string.Empty, column);
            var results = _factory.CreateChildren(root).ToList();
            Assert.That(results[0].Name, Is.EqualTo("Null"));
        }
    }
}
