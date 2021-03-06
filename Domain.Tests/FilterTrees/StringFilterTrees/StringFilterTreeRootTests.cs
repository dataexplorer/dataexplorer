﻿using System.Linq;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.FilterTrees.NullFilterTrees;
using DataExplorer.Domain.FilterTrees.StringFilterTrees;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.FilterTrees.StringFilterTrees
{
    [TestFixture]
    public class StringFilterTreeRootTests
    {
        [Test]
        public void TestConstructorShouldSetName()
        {
            var column = new ColumnBuilder().WithValue(0).Build();
            var root = new StringFilterTreeRoot("Test", column);
            Assert.That(root.Name, Is.EqualTo("Test"));
        }

        [Test]
        public void TestCreateChildrenShouldAddNullNodeIfColumnHasNulls()
        {
            var column = new ColumnBuilder().WithValue(string.Empty).WithNulls().Build();
            var root = new StringFilterTreeRoot(string.Empty, column);
            var results = root.CreateChildren();
            Assert.That(results.First() is NullFilterTreeLeaf, Is.True);
        }

        [Test]
        public void TestCreateChildrenShouldNotAddNullNodeIfColumnHasNoNulls()
        {
            var column = new ColumnBuilder().WithValue(string.Empty).Build();
            var root = new StringFilterTreeRoot(string.Empty, column);
            var results = root.CreateChildren();
            Assert.That(results.FirstOrDefault() is NullFilterTreeLeaf, Is.False);
        }

        [Test]
        public void TestCreateFilterShouldCreateNullableStringFilterIfColumnHasNulls()
        {
            var column = new ColumnBuilder()
                .WithNulls()
                .Build();
            var root = new StringFilterTreeRoot(string.Empty, column);
            var result = (StringFilter) root.CreateFilter();
            Assert.That(result.Value, Is.EqualTo(string.Empty));
            Assert.That(result.IncludeNull, Is.True);
        }

        [Test]
        public void TestCreateFilterShouldCreateStringFilterIfColumnDoesNotHasNulls()
        {
            var column = new ColumnBuilder()
                .WithValue("test")
                .Build();
            var root = new StringFilterTreeRoot(string.Empty, column);
            var result = root.CreateFilter();
            Assert.That(result is StringFilter);
        }
    }
}
