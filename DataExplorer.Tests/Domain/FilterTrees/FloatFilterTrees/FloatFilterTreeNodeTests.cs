using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.FloatFilterTrees;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Filters.FloatFilters;
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
            Assert.That(result.All(p => p is FloatFilterTreeLeaf));
        }

        [Test]
        public void TestCreateChildrenShouldReturnNodesIfMoreThanTenNodes()
        {
            var values = CreateValues(0d, 20, 1d);
            _column = new ColumnBuilder().WithValues(values).Build();
            _node = new FloatFilterTreeNode(string.Empty, _column, 0d, 20d);
            var result = _node.CreateChildren();
            Assert.That(result.All(p => p is FloatFilterTreeNode));
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
        public void TestCreateChildrenShouldCreateMinValueNodes()
        {
            var step = Double.MaxValue / 20d;
            var values = CreateValues(Double.MinValue, 20, step);;
            _column = new ColumnBuilder().WithValues(values).Build();
            _node = new FloatFilterTreeNode(string.Empty, _column, (double) _column.Min, (double) _column.Max);
            var results = _node.CreateChildren();
            Assert.That(results.First().Name, Is.EqualTo("-1.79769313486232E+308 - -1.7078084781192E+308"));
        }

        [Test]
        public void TestCreateChildrenShouldCreateMidValueNodes()
        {
            var values = CreateValues(-10, 20, 1d); ;
            _column = new ColumnBuilder().WithValues(values).Build();
            _node = new FloatFilterTreeNode(string.Empty, _column, (double)_column.Min, (double)_column.Max);
            var results = _node.CreateChildren();
            Assert.That(results.ElementAt(5).Name, Is.EqualTo("0 - 1"));
        }

        [Test]
        public void TestCreateChildrenShouldCreateMaxValueNodes()
        {
            var step = Double.MaxValue / 20d;
            var values = CreateValues(Double.MaxValue, 20, -step);
            values = values.Reverse();
            _column = new ColumnBuilder().WithValues(values).Build();
            _node = new FloatFilterTreeNode(string.Empty, _column, (double)_column.Min, (double)_column.Max);
            var results = _node.CreateChildren();
            Assert.That(results.Last().Name, Is.EqualTo("1.7078084781192E+308 - 1.79769313486232E+308"));
        }

        private IEnumerable<object> CreateValues(double start, int count, double step)
        {
            for (int i = 0; i < count; i++)
                yield return start + (i * step);
        }

        [Test]
        public void TestCreateFilterShouldReturnFilter()
        {
            var lowerValue = double.MinValue;
            var upperValue = double.MaxValue;
            _node = new FloatFilterTreeNode(string.Empty, _column, lowerValue, upperValue);
            var result = (FloatFilter) _node.CreateFilter();
            Assert.That(result.LowerValue, Is.EqualTo(lowerValue));
            Assert.That(result.UpperValue, Is.EqualTo(upperValue));
        }
    }
}
