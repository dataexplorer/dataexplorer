﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories.BooleanGridLines;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories.DateTimeGridLines;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories.FloatGridLines;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories.IntegerGridLines;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories.StringGridLines;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Tests.Maps.AxisMaps;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots.Axes.Factories
{
    [TestFixture]
    public class AxisGridLineFactoryTests
    {
        private GridLineFactory _factory;
        private Mock<IBooleanGridLineFactory> _mockBooleanFactory;
        private Mock<IDateTimeGridLineFactory> _mockDateTimeFactory;
        private Mock<IFloatGridLineFactory> _mockFloatFactory;
        private Mock<IIntegerGridLineFactory> _mockIntegerFactory;
        private Mock<IStringGridLineFactory> _mockStringFactory;
        private List<object> _sourceValues;
        private AxisMap _axisMap;
        private List<AxisGridLine> _gridLines;
        private AxisGridLine _gridGridLine;

        [SetUp]
        public void SetUp()
        {
            _sourceValues = new List<object>();
            _axisMap = new FakeAxisMap();
            _gridGridLine = new AxisGridLine();
            _gridLines = new List<AxisGridLine> { _gridGridLine };

            _mockBooleanFactory = new Mock<IBooleanGridLineFactory>();
            _mockDateTimeFactory = new Mock<IDateTimeGridLineFactory>();
            _mockFloatFactory = new Mock<IFloatGridLineFactory>();
            _mockIntegerFactory = new Mock<IIntegerGridLineFactory>();
            _mockStringFactory = new Mock<IStringGridLineFactory>();

            _factory = new GridLineFactory(
                _mockBooleanFactory.Object,
                _mockDateTimeFactory.Object,
                _mockFloatFactory.Object,
                _mockIntegerFactory.Object,
                _mockStringFactory.Object);
        }

        [Test]
        public void TestCreateShouldReturnBooleanGridLines()
        {
            _mockBooleanFactory.Setup(p => p.Create(_axisMap, 0d, 1d)).Returns(_gridLines);
            var results = _factory.Create(typeof(Boolean), _axisMap, _sourceValues, 0d, 1d);
            Assert.That(results.Single(), Is.EqualTo(_gridGridLine));
        }

        [Test]
        public void TestCreateShouldReturnDateTimeGridLines()
        {
            _mockDateTimeFactory.Setup(p => p.Create(_axisMap, 0d, 1d)).Returns(_gridLines);
            var results = _factory.Create(typeof(DateTime), _axisMap, _sourceValues, 0d, 1d);
            Assert.That(results.Single(), Is.EqualTo(_gridGridLine));
        }

        [Test]
        public void TestCreateShouldReturnFloatGridLines()
        {
            _mockFloatFactory.Setup(p => p.Create(_axisMap, 0d, 1d)).Returns(_gridLines);
            var results = _factory.Create(typeof(Double), _axisMap, _sourceValues, 0d, 1d);
            Assert.That(results.Single(), Is.EqualTo(_gridGridLine));
        }

        [Test]
        public void TestCreateShouldReturnIntegerGridLines()
        {
            _mockIntegerFactory.Setup(p => p.Create(_axisMap, 0d, 1d)).Returns(_gridLines);
            var results = _factory.Create(typeof(Int32), _axisMap, _sourceValues, 0d, 1d);
            Assert.That(results.Single(), Is.EqualTo(_gridGridLine));
        }

        [Test]
        public void TestCreateShouldReturnStringGridLines()
        {
            _mockStringFactory.Setup(p => p.Create(_axisMap, _sourceValues, 0d, 1d)).Returns(_gridLines);
            var results = _factory.Create(typeof(String), _axisMap, _sourceValues, 0d, 1d);
            Assert.That(results.Single(), Is.EqualTo(_gridGridLine));
        }

        [Test]
        public void TestCreateShouldReturnEmptyLinesIfNoMatchingType()
        {
            var results = _factory.Create(typeof(object), _axisMap, _sourceValues, 0d, 1d);
            Assert.That(results, Is.Empty);
        }
    }
}
