using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.DateTimeFilterTrees;
using DataExplorer.Domain.FilterTrees.NullFilterTrees;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Filters.DateTimeFilters;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.DateTimeFilterTrees
{
    [TestFixture]
    public class DateTimeFilterTreeRootTests
    {
        [Test]
        [TestCase("365242.0:0:0", typeof(MillenniumFilterTreeNode))]
        [TestCase("36524.0:0:0", typeof(CenturyFilterTreeNode))]
        [TestCase("3652.0:0:0", typeof(DecadeFilterTreeNode))]
        [TestCase("365.0:0:0", typeof(YearFilterTreeNode))]
        [TestCase("30.0:0:0", typeof(MonthFilterTreeNode))]
        [TestCase("1.0:0:0", typeof(DayFilterTreeNode))]
        [TestCase("0.1:0:0", typeof(HourFilterTreeNode))]
        [TestCase("0.0:1:0", typeof(MinuteFilterTreeNode))]
        [TestCase("0.0:0:1", typeof(SecondFilterTreeNode))]
        public void TestCreateChildrenShouldCreateChildren(string span, Type type)
        {
            var timeSpan = TimeSpan.Parse(span);
            var column = new ColumnBuilder()
                .WithValue(DateTime.MinValue)
                .WithValue(DateTime.MinValue + timeSpan)
                .Build();
            var root = new DateTimeFilterTreeRoot(string.Empty, column);
            var result = root.CreateChildren();
            Assert.That(result.First(), Is.TypeOf(type));
        }

        [Test]
        public void TestCreateChildrenShouldCreateNullLeafIfColumnHasNulls()
        {
            var column = new ColumnBuilder()
                .WithValue(DateTime.MinValue)
                .WithValue(DateTime.MinValue)
                .WithNulls()
                .Build();
            var root = new DateTimeFilterTreeRoot(string.Empty, column);
            var result = root.CreateChildren();
            Assert.That(result.Single() is NullFilterTreeLeaf);
        }

        [Test]
        public void TestCreateChildrenShouldNotCreateNullLeafIfColumnHasNoNulls()
        {
            var column = new ColumnBuilder()
                .WithValue(DateTime.MinValue)
                .WithValue(DateTime.MinValue)
                .Build();
            var root = new DateTimeFilterTreeRoot(string.Empty, column);
            var result = root.CreateChildren();
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void TestCreateChildrenShouldCreateMinMillennia()
        {
            var lower = DateTime.MinValue;
            var upper = DateTime.MinValue + TimeSpan.FromDays(365242);
            Test(lower, upper, 0, "0000s");
        }

        [Test]
        public void TestCreateChildrenShouldCreateMidMillennia()
        {
            var lower = new DateTime(5000, 1, 1);
            var upper = new DateTime(6000, 1, 1);
            Test(lower, upper, 0, "5000s");
        }

        [Test]
        public void TestCreateChildrenShouldCreateMaxMillennia()
        {
            var lower = DateTime.MaxValue - TimeSpan.FromDays(365242);
            var upper = DateTime.MaxValue;
            Test(lower, upper, 1, "9000s");
        }

        private void Test(DateTime lower, DateTime upper, int index, string name)
        {
            var column = new ColumnBuilder()
                .WithValue(lower)
                .WithValue(upper)
                .Build();
            var root = new DateTimeFilterTreeRoot(string.Empty, column);
            var result = root.CreateChildren();
            Assert.That(result.ElementAt(index).Name, Is.EqualTo(name));
            //TODO: Assert value
        }

        [Test]
        public void TestCreateFilterShouldCreateNullableDateTimeFilterIfColumnHasNulls()
        {
            var column = new ColumnBuilder()
                .WithValue(DateTime.MinValue)
                .WithValue(DateTime.MaxValue)
                .WithNulls().Build();
            var root = new DateTimeFilterTreeRoot(string.Empty, column);
            var result = (NullableDateTimeFilter) root.CreateFilter();
            Assert.That(result.LowerValue, Is.EqualTo(DateTime.MinValue));
            Assert.That(result.UpperValue, Is.EqualTo(DateTime.MaxValue));
            Assert.That(result.IncludeNulls, Is.True);
        }

        [Test]
        public void TestCreateFilterShouldCreateDateTimeFilterIfColumnDoesNotHasNulls()
        {
            var column = new ColumnBuilder()
                .WithValue(DateTime.MinValue)
                .WithValue(DateTime.MaxValue)
                .Build();
            var root = new DateTimeFilterTreeRoot(string.Empty, column);
            var result = root.CreateFilter();
            Assert.That(result is DateTimeFilter);
        }
    }
}
