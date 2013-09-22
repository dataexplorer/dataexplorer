﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Predicates;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.Filters
{
    [TestFixture]
    public class NullableDateTimeFilterTests
    {
        private NullableDateTimeFilter _filter;
        private Column _column;
        
        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();
            _filter = new NullableDateTimeFilter(_column, DateTime.MinValue, DateTime.MaxValue, true);
        }

        [Test]
        public void TestGetIncludeNullsShouldReturnValue()
        {
            var result = _filter.IncludeNulls;
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestCreatePredicateShouldReturnNullableBooleanPredicate()
        {
            var result = _filter.CreatePredicate();
            Assert.That(result, Is.Not.Null);
        }
    }
}
