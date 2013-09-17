using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.FloatFilterTrees;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.FloatFilterTrees
{
    [TestFixture]
    public class FloatFilterTreeNodeTests
    {
        private FloatFilterTreeNode _node;
        private Column _column;

        [Test]
        public void TestCreateChildrenShouldReturnLeavesIfLessThanTenNodes()
        {
            var values = CreateValues(0d, 10, 1d);
            _column = new ColumnBuilder().WithValues(values).Build();
            _node = new FloatFilterTreeNode(string.Empty, _column, 0d, 10d);
            var result = _node.CreateChildren();
            Assert.That(result.Count(), Is.EqualTo(10));
            Assert.That(result.All(p => p is FloatFilterTreeLeaf));
            Assert.That(result.First().Name, Is.EqualTo("0"));
            Assert.That(result.Last().Name, Is.EqualTo("9"));
        }

        [Test]
        public void TestCreateChildrenShouldCreateMinValueLeaf()
        {
            var value = double.MinValue;
            _column = new ColumnBuilder().WithValue(value).Build();
            _node = new FloatFilterTreeNode(string.Empty, _column, value, value);
            var results = _node.CreateChildren();
            Assert.That(results.Single().Name, Is.EqualTo("-1.79769313486232E+308"));
        }

        [Test]
        public void TestCreateChildrenShouldCreateMidValueLeaf()
        {
            var value = 0d;
            _column = new ColumnBuilder().WithValue(value).Build();
            _node = new FloatFilterTreeNode(string.Empty, _column, value, value);
            var results = _node.CreateChildren();
            Assert.That(results.Single().Name, Is.EqualTo("0"));
        }

        [Test]
        public void TestCreateChildrenShouldCreateMaxValueLeaf()
        {
            var value = double.MaxValue;
            _column = new ColumnBuilder().WithValue(value).Build();
            _node = new FloatFilterTreeNode(string.Empty, _column, value, value);
            var results = _node.CreateChildren();
            Assert.That(results.Single().Name, Is.EqualTo("1.79769313486232E+308"));
        }

        [Test]
        public void TestCreateChildrenShouldReturnNodesIfMoreThanTenNodes()
        {
            var values = CreateValues(0d, 20, 1d);
            _column = new ColumnBuilder().WithValues(values).Build();
            _node = new FloatFilterTreeNode(string.Empty, _column, 0d, 20d);
            var result = _node.CreateChildren();
            Assert.That(result.Count(), Is.EqualTo(10));
            Assert.That(result.All(p => p is FloatFilterTreeNode));
            Assert.That(result.First().Name, Is.EqualTo("0 - 1"));
            Assert.That(result.Last().Name, Is.EqualTo("18 - 19"));
        }

        [Test]
        public void TestCreateChildrenShouldCreateMinValueNodes()
        {
            var values = CreateValues(Double.MinValue, 10, 1d);;
            _column = new ColumnBuilder().WithValues(values).Build();
            _node = new FloatFilterTreeNode(string.Empty, _column, (double) _column.Min, (double) _column.Max);
            var results = _node.CreateChildren();
            Assert.That(results.First().Name, Is.EqualTo("-1.79769313486232E+308"));
        }

        [Test]
        public void TestCreateChildrenShouldCreateMidValueNodes()
        {
            var values = CreateValues(-5, 10, 1d); ;
            _column = new ColumnBuilder().WithValues(values).Build();
            _node = new FloatFilterTreeNode(string.Empty, _column, (double)_column.Min, (double)_column.Max);
            var results = _node.CreateChildren();
            Assert.That(results.ElementAt(5).Name, Is.EqualTo("0"));
        }

        [Test]
        public void TestCreateChildrenShouldCreateMaxValueNodes()
        {
            var values = CreateValues(Double.MaxValue, 20, -1d); ;
            _column = new ColumnBuilder().WithValues(values).Build();
            _node = new FloatFilterTreeNode(string.Empty, _column, (double)_column.Min, (double)_column.Max);
            var results = _node.CreateChildren();
            Assert.That(results.First().Name, Is.EqualTo("1.79769313486232E+308"));
        }

        private IEnumerable<object> CreateValues(double start, int count, double step)
        {
            for (int i = 0; i < count; i++)
                yield return start + (i * step);
        }
    }
}
