﻿using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Tests.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots;
using DataExplorer.Presentation.Views.ScatterPlots.Queries;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views
{
    [TestFixture]
    public class ScatterPlotViewModelQueriesTests
    {
        private ScatterPlotViewModelQueries _queries;
        private Mock<IGetAllItemsQuery> _mockGetItemsQuery;
        private Mock<IGetSelectedItemsQuery> _mockGetSelectedItemsQuery;
        private FakeCanvasItem _item;
        private List<CanvasItem> _items;
        private Size _controlSize;

        [SetUp]
        public void SetUp()
        {
            _item = new FakeCanvasItem();
            _items = new List<CanvasItem> { _item };
            _controlSize = new Size();

            _mockGetItemsQuery = new Mock<IGetAllItemsQuery>();
            _mockGetItemsQuery.Setup(p => p.Execute(_controlSize)).Returns(_items);

            _mockGetSelectedItemsQuery = new Mock<IGetSelectedItemsQuery>();
            _mockGetSelectedItemsQuery.Setup(p => p.Execute(_items)).Returns(_items);

            _queries = new ScatterPlotViewModelQueries(
                _mockGetItemsQuery.Object,
                _mockGetSelectedItemsQuery.Object);
        }

        [Test]
        public void TestGetItemsShouldReturnItems()
        {
            var results = _queries.GetItems(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_item));
        }

        [Test]
        public void TestGetSelectedItemsShouldReturnItems()
        {
            var results = _queries.GetSelectedItems(_items);
            Assert.That(results.Single(), Is.EqualTo(_item));
        }
    }
}
