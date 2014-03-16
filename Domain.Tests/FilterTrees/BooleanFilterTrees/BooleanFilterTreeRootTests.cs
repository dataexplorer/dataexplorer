using System.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.FilterTrees.BooleanFilterTrees;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.FilterTrees.BooleanFilterTrees
{
    [TestFixture]
    public class BooleanFilterTreeRootTests
    {
        private Column _column;
        private BooleanFilterTreeRoot _node;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();
            _node = new BooleanFilterTreeRoot("Test", _column);
        }

        [Test]
        public void TestCreateChildrenShouldCreateFalseLeaf()
        {
            var results = _node.CreateChildren().ToList();
            Assert.That(results[0].Name, Is.EqualTo("False"));
        }

        [Test]
        public void TestCreateChildrenShouldCreateTrueLeaf()
        {
            var results = _node.CreateChildren().ToList();
            Assert.That(results[1].Name, Is.EqualTo("True"));
        }

        [Test]
        public void TestCreateChildrenShouldNotCreateNullLeafIfColumnHasNoNulls()
        {
            var results = _node.CreateChildren().ToList();
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
            var result = (BooleanFilter) _node.CreateFilter();
            Assert.That(result.IncludeTrue, Is.True);
            Assert.That(result.IncludeFalse, Is.True);
        }
    }
}
