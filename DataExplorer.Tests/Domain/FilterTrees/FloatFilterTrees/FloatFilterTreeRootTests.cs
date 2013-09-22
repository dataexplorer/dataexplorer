﻿using System.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.FloatFilterTrees;
using DataExplorer.Domain.FilterTrees.NullFilterTrees;
using DataExplorer.Domain.Filters;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.FloatFilterTrees
{
    [TestFixture]
    public class FloatFilterTreeRootTests
    {
        private FloatFilterTreeRoot _root;
        private Column _column;

        [Test]
        public void TestConstructorShouldSetName()
        {
            _column = new ColumnBuilder().WithValue(0.0d).Build();
            _root = new FloatFilterTreeRoot("Test", _column);
            Assert.That(_root.Name, Is.EqualTo("Test"));
        }

        [Test]
        public void TestCreateChildrenShouldAddNullNodeIfColumnHasNulls()
        {
            _column = new ColumnBuilder().WithValue(0d).WithNulls().Build();
            _root = new FloatFilterTreeRoot(string.Empty, _column);
            var results = _root.CreateChildren();
            Assert.That(results.First() is NullFilterTreeLeaf, Is.True);
        }

        [Test]
        public void TestCreateChildrenShouldNotAddNullNodeIfColumnHasNoNulls()
        {
            _column = new ColumnBuilder().WithValue(0d).Build();
            _root = new FloatFilterTreeRoot(string.Empty, _column);
            var results = _root.CreateChildren();
            Assert.That(results.First() is NullFilterTreeLeaf, Is.False);
        }

        [Test]
        public void TestCreateFilterShouldCreateNullableFloatFilterIfColumnHasNulls()
        {
            var column = new ColumnBuilder()
                .WithValue(double.MinValue)
                .WithValue(double.MaxValue)
                .WithNulls().Build();
            var root = new FloatFilterTreeRoot(string.Empty, column);
            var result = (NullableFloatFilter) root.CreateFilter();
            Assert.That(result.LowerValue, Is.EqualTo(double.MinValue));
            Assert.That(result.UpperValue, Is.EqualTo(double.MaxValue));
            Assert.That(result.IncludeNulls, Is.True);
        }

        [Test]
        public void TestCreateFilterShouldCreateFloatFilterIfColumnDoesNotHasNulls()
        {
            var column = new ColumnBuilder()
                .WithValue(double.MinValue)
                .WithValue(double.MaxValue)
                .Build();
            var root = new FloatFilterTreeRoot(string.Empty, column);
            var result = root.CreateFilter();
            Assert.That(result is FloatFilter);
        }
    }
}
