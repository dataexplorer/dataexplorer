using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Legends.Sizes.Factories;
using DataExplorer.Domain.Maps.SizeMaps;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Legends.Sizes.Factories
{
    [TestFixture]
    public class DateTimeSizeLegendFactoryTests
    {
        private DateTimeSizeLegendFactory _factory;
        private Mock<SizeMap> _mockSizeMap;
        private List<DateTime?> _values;
        private DateTime? _value;
        private double? _size;
        private double _lowerSize;
        private double _upperSize;

        [SetUp]
        public void SetUp()
        {
            _values = new List<DateTime?>();
            _value = new DateTime(2001, 01, 01);
            _size = 0d;
            _lowerSize = 0d;
            _upperSize = 1d;

            _mockSizeMap = new Mock<SizeMap>();
            _mockSizeMap.Setup(p => p.Map(It.IsAny<DateTime?>()))
                .Returns(_size);
            _mockSizeMap.Setup(p => p.MapInverse(It.IsAny<double>()))
                .Returns(_value);

            _factory = new DateTimeSizeLegendFactory();
        }

        [Test]
        public void TestCreateShouldCreateDiscreteItemsIfValuesLessThanFour()
        {
            AssertResult(3, 3);
        }

        [Test]
        public void TestCreateShouldCreateDiscreteItemsIfValuesAreEqualToFour()
        {
            AssertResult(4, 4);
        }

        [Test]
        public void TestCreateShouldCreateContinuousItemsIfValuesAreGreaterThanFour()
        {
            AssertResult(5, 3);
        }

        private void AssertResult(int valueCount, int expectedItemCount)
        {
            for (var i = 0; i < valueCount; i++)
                _values.Add(_value.Value.AddDays(i));

            var results = _factory.Create(_mockSizeMap.Object, _values, _lowerSize, _upperSize);
            Assert.That(results.Count(), Is.EqualTo(expectedItemCount));
            Assert.That(results.First().Size, Is.EqualTo(_size));
            Assert.That(results.First().Label, Is.EqualTo(_value.Value.ToShortDateString()));
        }
    }
}
