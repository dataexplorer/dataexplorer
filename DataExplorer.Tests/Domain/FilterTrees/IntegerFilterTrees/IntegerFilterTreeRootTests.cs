using System.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.IntegerFilterTrees;
using DataExplorer.Domain.FilterTrees.NullFilterTrees;
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
    }
}
