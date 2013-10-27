using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories.BooleanAxisGridLines;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories.DateTimeAxisGridLines;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories.FloatAxisGridLines;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories.IntegerAxisGridLines;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories.StringAxisGridLines;
using DataExplorer.Tests.Application.Maps;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.AxisGridLines.Factories
{
    [TestFixture]
    public class ScatterPlotAxisGridLineFactoryTests
    {
        private ScatterPlotAxisGridLineFactory _factory;
        private Mock<IBooleanAxisGridLineFactory> _mockBooleanFactory;
        private Mock<IDateTimeAxisGridLineFactory> _mockDateTimeFactory;
        private Mock<IFloatAxisGridLineFactory> _mockFloatFactory;
        private Mock<IIntegerAxisGridLineFactory> _mockIntegerFactory;
        private Mock<IStringAxisGridLineFactory> _mockStringFactory;
        private IAxisMap _axisMap;
        private List<AxisLine> _gridLines;
        private AxisLine _gridLine;

        [SetUp]
        public void SetUp()
        {
            _axisMap = new FakeAxisMap();
            _gridLine = new AxisLine();
            _gridLines = new List<AxisLine> { _gridLine };

            _mockBooleanFactory = new Mock<IBooleanAxisGridLineFactory>();
            _mockDateTimeFactory = new Mock<IDateTimeAxisGridLineFactory>();
            _mockFloatFactory = new Mock<IFloatAxisGridLineFactory>();
            _mockIntegerFactory = new Mock<IIntegerAxisGridLineFactory>();
            _mockStringFactory = new Mock<IStringAxisGridLineFactory>();

            _factory = new ScatterPlotAxisGridLineFactory(
                _mockBooleanFactory.Object,
                _mockDateTimeFactory.Object,
                _mockFloatFactory.Object,
                _mockIntegerFactory.Object,
                _mockStringFactory.Object);
        }

        [Test]
        public void TestCreateShouldReturnBooleanGridLines()
        {
            _mockBooleanFactory.Setup(p => p.Create(_axisMap)).Returns(_gridLines);
            var results = _factory.Create(typeof(Boolean), _axisMap, 0, 1);
            Assert.That(results.Single(), Is.EqualTo(_gridLine));
        }

        [Test]
        public void TestCreateShouldReturnDateTimeGridLines()
        {
            _mockDateTimeFactory.Setup(p => p.Create()).Returns(_gridLines);
            var results = _factory.Create(typeof(DateTime), _axisMap, 0, 1);
            Assert.That(results.Single(), Is.EqualTo(_gridLine));
        }

        [Test]
        public void TestCreateShouldReturnFloatGridLines()
        {
            _mockFloatFactory.Setup(p => p.Create()).Returns(_gridLines);
            var results = _factory.Create(typeof(Double), _axisMap, 0, 1);
            Assert.That(results.Single(), Is.EqualTo(_gridLine));
        }

        [Test]
        public void TestCreateShouldReturnIntegerGridLines()
        {
            _mockIntegerFactory.Setup(p => p.Create()).Returns(_gridLines);
            var results = _factory.Create(typeof(Int32), _axisMap, 0, 1);
            Assert.That(results.Single(), Is.EqualTo(_gridLine));
        }

        [Test]
        public void TestCreateShouldReturnStringGridLines()
        {
            _mockStringFactory.Setup(p => p.Create()).Returns(_gridLines);
            var results = _factory.Create(typeof(String), _axisMap, 0, 1);
            Assert.That(results.Single(), Is.EqualTo(_gridLine));
        }

        [Test]
        public void TestCreateShouldReturnEmptyLinesIfNoMatchingType()
        {
            var results = _factory.Create(typeof(object), _axisMap, 0, 1);
            Assert.That(results, Is.Empty);
        }
    }
}
