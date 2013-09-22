using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.IntegerFilterTrees;
using DataExplorer.Domain.Filters;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.IntegerFilterTrees
{
    [TestFixture]
    public class IntegerFilterTreeNodeTests
    {
        private IntegerFilterTreeNode _node;
        private Column _column;

        [Test]
        public void TestCreateChildrenShouldReturnLeavesIfLessThanOrEqualToTenNodes()
        {
            var values = CreateValues(0, 10, 1);
            _column = new ColumnBuilder().WithValues(values).Build();
            _node = new IntegerFilterTreeNode(string.Empty, _column, 0, 10);
            var result = _node.CreateChildren();
            Assert.That(result.All(p => p is IntegerFilterTreeLeaf));
        }

        [Test]
        public void TestCreateChildrenShouldReturnNodesIfMoreThanTenNodes()
        {
            var values = CreateValues(0, 20, 1);
            _column = new ColumnBuilder().WithValues(values).Build();
            _node = new IntegerFilterTreeNode(string.Empty, _column, 0, 20);
            var result = _node.CreateChildren();
            Assert.That(result.All(p => p is IntegerFilterTreeNode));
        }

        [Test]
        public void TestCreateChildrenShouldCreateMinValueLeaf()
        {
            var value = int.MinValue;
            _column = new ColumnBuilder().WithValue(value).Build();
            _node = new IntegerFilterTreeNode(string.Empty, _column, value, value);
            var results = _node.CreateChildren();
            Assert.That(results.Single().Name, Is.EqualTo("-2147483648"));
        }

        [Test]
        public void TestCreateChildrenShouldCreateMidValueLeaf()
        {
            var value = 0;
            _column = new ColumnBuilder().WithValue(value).Build();
            _node = new IntegerFilterTreeNode(string.Empty, _column, value, value);
            var results = _node.CreateChildren();
            Assert.That(results.Single().Name, Is.EqualTo("0"));
        }

        [Test]
        public void TestCreateChildrenShouldCreateMaxValueLeaf()
        {
            var value = int.MaxValue;
            _column = new ColumnBuilder().WithValue(value).Build();
            _node = new IntegerFilterTreeNode(string.Empty, _column, value, value);
            var results = _node.CreateChildren();
            Assert.That(results.Single().Name, Is.EqualTo("2147483647"));
        }

       

        [Test]
        public void TestCreateChildrenShouldCreateMinValueNodes()
        {
            var values = CreateValues(int.MinValue, 20, 1); ;
            _column = new ColumnBuilder().WithValues(values).Build();
            _node = new IntegerFilterTreeNode(string.Empty, _column, (int)_column.Min, (int)_column.Max);
            var results = _node.CreateChildren();
            Assert.That(results.First().Name, Is.EqualTo("-2147483648 - -2147483647"));
        }

        [Test]
        public void TestCreateChildrenShouldCreateMidValueNodes()
        {
            var values = CreateValues(-10, 20, 1); ;
            _column = new ColumnBuilder().WithValues(values).Build();
            _node = new IntegerFilterTreeNode(string.Empty, _column, (int)_column.Min, (int)_column.Max);
            var results = _node.CreateChildren();
            Assert.That(results.ElementAt(5).Name, Is.EqualTo("0 - 1"));
        }

        [Test]
        public void TestCreateChildrenShouldCreateMaxValueNodes()
        {
            var values = CreateValues(int.MaxValue - 19, 20, 1); ;
            _column = new ColumnBuilder().WithValues(values).Build();
            _node = new IntegerFilterTreeNode(string.Empty, _column, (int)_column.Min, (int)_column.Max);
            var results = _node.CreateChildren();
            Assert.That(results.Last().Name, Is.EqualTo("2147483646 - 2147483647"));
        }

        private IEnumerable<object> CreateValues(int start, int count, int step)
        {
            for (int i = 0; i < count; i++)
                yield return start + (i * step);
        }

        [Test]
        public void TestCreateFilterShouldReturnFilter()
        {
            var lowerValue = int.MinValue;
            var upperValue = int.MaxValue;
            _node = new IntegerFilterTreeNode(string.Empty, _column, lowerValue, upperValue);
            var result = (IntegerFilter) _node.CreateFilter();
            Assert.That(result.LowerValue, Is.EqualTo(lowerValue));
            Assert.That(result.UpperValue, Is.EqualTo(upperValue));
        }
    }
}
