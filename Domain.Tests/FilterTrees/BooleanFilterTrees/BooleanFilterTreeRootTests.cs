using System.Linq;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.FilterTrees.BooleanFilterTrees;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.FilterTrees.BooleanFilterTrees
{
    [TestFixture]
    public class BooleanFilterTreeRootTests
    {
        [Test]
        public void TestCreateChildrenShouldCreateFalseLeaf()
        {
            var column = new ColumnBuilder().Build();
            var node = new BooleanFilterTreeRoot("Test", column);
            var results = node.CreateChildren().ToList();
            Assert.That(results[0].Name, Is.EqualTo("False"));
        }

        [Test]
        public void TestCreateChildrenShouldCreateTrueLeaf()
        {
            var column = new ColumnBuilder().Build();
            var node = new BooleanFilterTreeRoot("Test", column);
            var results = node.CreateChildren().ToList();
            Assert.That(results[1].Name, Is.EqualTo("True"));
        }

        [Test]
        public void TestCreateChildrenShouldNotCreateNullLeafIfColumnHasNoNulls()
        {
            var column = new ColumnBuilder().Build();
            var node = new BooleanFilterTreeRoot("Test", column);
            var results = node.CreateChildren().ToList();
            Assert.That(results[0].Name, Is.Not.EqualTo("Null"));
        }

        [Test]
        public void TestCreateChildrenShouldCreateNullLeafIfColumnHasNulls()
        {
            var column = new ColumnBuilder().WithNulls().Build();
            var node = new BooleanFilterTreeRoot("Test", column);
            var results = node.CreateChildren().ToList();
            Assert.That(results[0].Name, Is.EqualTo("Null"));
        }

        [Test]
        public void TestCreateFilterShouldReturnFilter()
        {
            var column = new ColumnBuilder().Build();
            var node = new BooleanFilterTreeRoot(string.Empty, column);
            var result = (BooleanFilter) node.CreateFilter();
            Assert.That(result.IncludeTrue, Is.True);
            Assert.That(result.IncludeFalse, Is.True);
        }
    }
}
