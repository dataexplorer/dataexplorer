using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.FilterTrees.StringFilterTrees;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Filters.StringFilters;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.StringFilterTrees
{
    [TestFixture]
    public class StringFilterTreeNodeTests
    {
        [Test]
        public void TestCreateChildrenShouldReturnLeavesIfLessThanOrEqualToTenNodes()
        {
            var values = CreateValues(10);
            var column = new ColumnBuilder().WithValues(values).Build();
            var node = new StringFilterTreeNode(string.Empty, column, string.Empty, 1);
            var result = node.CreateChildren();
            Assert.That(result.All(p => p is StringFilterTreeLeaf));
        }

        [Test]
        public void TestCreateShouldReturnLeavesAfterMaxDepthOfThree()
        {
            var values = CreateDeepValues('A', 20, 4);
            var column = new ColumnBuilder().WithValues(values).Build();
            var root = new StringFilterTreeRoot(string.Empty, column);
            var node1 = root.CreateChildren().Single();
            var node2 = node1.CreateChildren().Single();
            var node3 = node2.CreateChildren().Single();
            var result = node3.CreateChildren();
            Assert.That(result.All(p => p is StringFilterTreeLeaf));
        }

        [Test]
        public void TestCreateChildrenShouldReturnNodesIfMoreThanTenNodes()
        {
            var values = CreateValues(20);
            var column = new ColumnBuilder().WithValues(values).Build();
            var node = new StringFilterTreeNode(string.Empty, column, string.Empty, 1);
            var result = node.CreateChildren();
            Assert.That(result.All(p => p is StringFilterTreeNode));
        }

        [Test]
        public void TestCreateChildrenShouldReturnLeafIfChildValueStartsWithParentValue()
        {
            var column = new ColumnBuilder().WithValue("Apple").Build();
            var node = new StringFilterTreeNode(string.Empty, column, string.Empty, 1);
            var result = node.CreateChildren();
            Assert.That(result.First().Name, Is.EqualTo("Apple"));
        }

        [Test]
        public void TestCreateChildrenShouldNotReturnLeafIfChildValueDoesNotStartWithParentValue()
        {
            var column = new ColumnBuilder().WithValue("Apple").Build();
            var node = new StringFilterTreeNode(string.Empty, column, "B", 1);
            var result = node.CreateChildren();
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void TestCreateChildrenShouldReturnNodeIfChildValueStartsWithParentValue()
        {
            var values = CreateValues(20);
            var column = new ColumnBuilder().WithValues(values).Build();
            var node = new StringFilterTreeNode(string.Empty, column, string.Empty, 1);
            var result = node.CreateChildren();
            Assert.That(result.First().Name, Is.EqualTo("A"));
        }

        [Test]
        public void TestCreateChildrenShouldNotReturnNodeIfChildValueDoesNotStartWithParentValue()
        {
            var values = CreateValues(20);
            var column = new ColumnBuilder().WithValues(values).Build();
            var node = new StringFilterTreeNode(string.Empty, column, "Z", 1);
            var result = node.CreateChildren();
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void TestCreateChildrenShouldCreateMinValueNode()
        {
            var values = CreateValues((char) 32, 20);
            var column = new ColumnBuilder().WithValues(values).Build();
            var node = new StringFilterTreeNode(string.Empty, column, string.Empty, 1);
            var result = node.CreateChildren();
            Assert.That(result.First().Name, Is.EqualTo(((char) 32).ToString()));
        }

        [Test]
        public void TestCreateChildrenShouldCreateMaxValueNode()
        {
            var values = CreateValues((char) (96 - 19), 20);
            var column = new ColumnBuilder().WithValues(values).Build();
            var node = new StringFilterTreeNode(string.Empty, column, string.Empty, 1);
            var result = node.CreateChildren();
            Assert.That(result.Last().Name, Is.EqualTo(((char) 96).ToString()));
        }

        private IEnumerable<object> CreateValues(int count)
        {
            return CreateValues('A', count);
        }

        private IEnumerable<object> CreateValues(char start, int count)
        {
            for (var i = 0; i < count; i++)
                yield return ((char) (start + i)).ToString();
        }

        private IEnumerable<object> CreateDeepValues(char start, int count, int depth)
        {
            for (var i = 0; i < count; i++)
                yield return new string(start, depth - 1) + ((char)(start + i)).ToString();
        }

        [Test]
        public void TestCreateFilterShouldReturnFilter()
        {
            var value = "Test";
            var column = new ColumnBuilder().Build();
            var node = new StringFilterTreeNode(string.Empty, column, value, 0);
            var result = (StringFilter) node.CreateFilter();
            Assert.That(result.Value, Is.EqualTo(value));
        }
    }
}
