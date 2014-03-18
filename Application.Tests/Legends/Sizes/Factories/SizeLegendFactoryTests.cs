using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Legends.Sizes.Factories;
using DataExplorer.Domain.Maps.SizeMaps;
using DataExplorer.Domain.Tests.Maps;
using DataExplorer.Domain.Tests.Maps.SizeMaps;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Legends.Sizes.Factories
{
    [TestFixture]
    public class SizeLegendFactoryTests
    {
        private SizeLegendFactory _factory;
        private Mock<IBooleanSizeLegendFactory> _mockBooleanFactory;
        private Mock<IDateTimeSizeLegendFactory> _mockDateTimeFactory;
        private Mock<IFloatSizeLegendFactory> _mockFloatFactory;
        private Mock<IIntegerSizeLegendFactory> _mockIntegerFactory;
        private Mock<IStringSizeLegendFactory> _mockStringFactory;

        private SizeMap _colorMap;
        private List<object> _values;
        private double _lowerSize;
        private double _upperSize;
        
        [SetUp]
        public void SetUp()
        {
            _colorMap = new FakeSizeMap();
            _values = new List<object>();
            _lowerSize = 0d;
            _upperSize = 1d;

            _mockBooleanFactory = new Mock<IBooleanSizeLegendFactory>();
            _mockDateTimeFactory = new Mock<IDateTimeSizeLegendFactory>();
            _mockFloatFactory = new Mock<IFloatSizeLegendFactory>();
            _mockIntegerFactory = new Mock<IIntegerSizeLegendFactory>();
            _mockStringFactory = new Mock<IStringSizeLegendFactory>();

            _factory = new SizeLegendFactory(
                _mockBooleanFactory.Object,
                _mockDateTimeFactory.Object,
                _mockFloatFactory.Object,
                _mockIntegerFactory.Object,
                _mockStringFactory.Object);
        }

        [Test]
        public void TestCreateBooleanSizeLegendItems()
        {
            _factory.Create(typeof(Boolean), _colorMap, _values, _lowerSize, _upperSize);
            _mockBooleanFactory.Verify(p => p.Create(_colorMap, It.IsAny<List<bool?>>(), _lowerSize, _upperSize), Times.Once());
        }

        [Test]
        public void TestCreateDateTimeSizeLegendItems()
        {
            _factory.Create(typeof(DateTime), _colorMap, _values, _lowerSize, _upperSize);
            _mockDateTimeFactory.Verify(p => p.Create(_colorMap, It.IsAny<List<DateTime?>>(), _lowerSize, _upperSize), Times.Once());
        }

        [Test]
        public void TestCreateFloatSizeLegendItems()
        {
            _factory.Create(typeof(Double), _colorMap, _values, _lowerSize, _upperSize);
            _mockFloatFactory.Verify(p => p.Create(_colorMap, It.IsAny<List<double?>>(), _lowerSize, _upperSize), Times.Once());
        }

        [Test]
        public void TestCreateIntegerSizeLegendItems()
        {
            _factory.Create(typeof(Int32), _colorMap, _values, _lowerSize, _upperSize);
            _mockIntegerFactory.Verify(p => p.Create(_colorMap, It.IsAny<List<int?>>(), _lowerSize, _upperSize), Times.Once());
        }

        [Test]
        public void TestCreateStringSizeLegendItems()
        {
            _factory.Create(typeof(String), _colorMap, _values, _lowerSize, _upperSize);
            _mockStringFactory.Verify(p => p.Create(_colorMap, It.IsAny<List<string>>(), _lowerSize, _upperSize), Times.Once());
        }
    }
}
