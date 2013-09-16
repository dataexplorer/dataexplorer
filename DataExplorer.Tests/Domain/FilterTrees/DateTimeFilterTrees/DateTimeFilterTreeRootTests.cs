using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.DateTimeFilterTrees;
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
        public void TestCreateChildrenShouldCreateMinMillennia()
        {
            var column = new ColumnBuilder()
                .WithValue(DateTime.MinValue)
                .WithValue(DateTime.MinValue + TimeSpan.FromDays(365242))
                .Build();
            var root = new DateTimeFilterTreeRoot(string.Empty, column);
            var result = root.CreateChildren();
            Assert.That(result.First().Name, Is.EqualTo("0000s"));
            //TODO: Assert value
        }

        [Test]
        public void TestCreateChildrenShouldCreateMaxMillennia()
        {
            var column = new ColumnBuilder()
                .WithValue(DateTime.MaxValue - TimeSpan.FromDays(365242))
                .WithValue(DateTime.MaxValue)
                .Build();
            var root = new DateTimeFilterTreeRoot(string.Empty, column);
            var result = root.CreateChildren();
            Assert.That(result.Last().Name, Is.EqualTo("9000s"));
            //TODO: Assert value
        }

        [Test]
        public void TestCreateChildrenShouldCreateMidMillennia()
        {
            var column = new ColumnBuilder()
                .WithValue(new DateTime(5000, 1, 1))
                .WithValue(new DateTime(6000, 1, 1))
                .Build();
            var root = new DateTimeFilterTreeRoot(string.Empty, column);
            var result = root.CreateChildren();
            Assert.That(result.First().Name, Is.EqualTo("5000s"));
            //TODO: Assert value
        }
    }
}
