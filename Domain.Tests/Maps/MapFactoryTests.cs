﻿using System;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Maps.ColorMaps;
using DataExplorer.Domain.Maps.LabelMaps;
using DataExplorer.Domain.Maps.SizeMaps;
using DataExplorer.Domain.Tests.Colors;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.Maps.AxisMaps;
using DataExplorer.Domain.Tests.Maps.ColorMaps;
using DataExplorer.Domain.Tests.Maps.LabelMaps;
using DataExplorer.Domain.Tests.Maps.SizeMaps;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Maps
{
    [TestFixture]
    public class MapFactoryTests
    {
        private MapFactory _factory;
        private Mock<IAxisMapFactory> _mockAxisMapFactory;
        private Mock<IColorMapFactory> _mockColorMapFactory;
        private Mock<ISizeMapFactory> _mockSizeMapFactory;
        private Mock<ILabelMapFactory> _mockLabelMapFactory;
        private Column _column;
        private ColorPalette _colorPalette;
        private AxisMap _axisMap;
        private ColorMap _colorMap;
        private SizeMap _sizeMap;
        private LabelMap _labelMap;

        [SetUp]
        public void SetUp()
        {
            _axisMap = new FakeAxisMap();
            _colorMap = new FakeColorMap();
            _sizeMap = new FakeSizeMap();
            _labelMap = new FakeLabelMap();

            _column = new ColumnBuilder().Build();
            _colorPalette = new ColorPaletteBuilder().Build();

            _mockAxisMapFactory = new Mock<IAxisMapFactory>();
            _mockAxisMapFactory.Setup(p => p.Create(_column, 0d, 1d, SortOrder.Ascending))
                .Returns(_axisMap);

            _mockColorMapFactory = new Mock<IColorMapFactory>();
            _mockColorMapFactory.Setup(p => p.Create(_column, _colorPalette, SortOrder.Ascending))
                .Returns(_colorMap);
            
            _mockSizeMapFactory = new Mock<ISizeMapFactory>();
            _mockSizeMapFactory.Setup(p => p.Create(_column, 0d, 1d, SortOrder.Ascending))
                .Returns(_sizeMap);

            _mockLabelMapFactory = new Mock<ILabelMapFactory>();
            _mockLabelMapFactory.Setup(p => p.Create(_column))
                .Returns(_labelMap);

            _factory = new MapFactory(
                _mockAxisMapFactory.Object,
                _mockColorMapFactory.Object,
                _mockSizeMapFactory.Object,
                _mockLabelMapFactory.Object);
        }
        
        [Test]
        public void TestCreateAxisMapForBooleanShouldReturnABooleanToAxisMap()
        {
            var result = _factory.CreateAxisMap(_column, 0d, 1d, SortOrder.Ascending);
            
            Assert.That(result, Is.EqualTo(_axisMap));
        }

        [Test]
        public void TestCreateColorMapShouldReturnColorMap()
        {
            var result = _factory.CreateColorMap(_column, _colorPalette, SortOrder.Ascending);
            
            Assert.That(result, Is.EqualTo(_colorMap));
        }

        [Test]
        public void TestCreateLabelMapShouldReturnLabelMap()
        {
            var result = _factory.CreateLabelMap(_column);

            Assert.That(result, Is.EqualTo(_labelMap));
        }
    }
}
