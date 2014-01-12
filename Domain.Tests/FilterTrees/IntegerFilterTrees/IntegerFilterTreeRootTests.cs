using System.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.IntegerFilterTrees;
using DataExplorer.Domain.FilterTrees.NullFilterTrees;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Filters.IntegerFilters;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.IntegerFilterTrees
{
    [TestFixture]
    public class IntegerFilterTreeRootTests
    {
        [Test]
        public void TestConstructorShouldSetName()
        {
            var column = new ColumnBuilder().WithValue(0).Build();
            var root = new IntegerFilterTreeRoot("Test", column);
            Assert.That(root.Name, Is.EqualTo("Test"));
        }

        [Test]
        public void TestCreateChildrenShouldAddNullNodeIfColumnHasNulls()
        {
            var column = new ColumnBuilder().WithValue(0).WithNulls().Build();
            var root = new IntegerFilterTreeRoot(string.Empty, column);
            var results = root.CreateChildren();
            Assert.That(results.First() is NullFilterTreeLeaf, Is.True);
        }

        [Test]
        public void TestCreateChildrenShouldNotAddNullNodeIfColumnHasNoNulls()
        {
            var column = new ColumnBuilder().WithValue(0).Build();
            var root = new IntegerFilterTreeRoot(string.Empty, column);
            var results = root.CreateChildren();
            Assert.That(results.FirstOrDefault() is NullFilterTreeLeaf, Is.False);
        }

        [Test]
        public void TestCreateFilterShouldCreateNullableIntegerFilterIfColumnHasNulls()
        {
            var column = new ColumnBuilder()
                .WithValue(int.MinValue)
                .WithValue(int.MaxValue)
                .WithNulls().Build();
            var root = new IntegerFilterTreeRoot(string.Empty, column);
            var result = (NullableIntegerFilter)root.CreateFilter();
            Assert.That(result.LowerValue, Is.EqualTo(int.MinValue));
            Assert.That(result.UpperValue, Is.EqualTo(int.MaxValue));
            Assert.That(result.IncludeNulls, Is.True);
        }

        [Test]
        public void TestCreateFilterShouldCreateIntegerFilterIfColumnDoesNotHasNulls()
        {
            var column = new ColumnBuilder()
                .WithValue(int.MinValue)
                .WithValue(int.MaxValue)
                .Build();
            var root = new IntegerFilterTreeRoot(string.Empty, column);
            var result = root.CreateFilter();
            Assert.That(result is IntegerFilter);
        }
    }
}
