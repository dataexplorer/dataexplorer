using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Legends.Sizes.Factories;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.SizeMaps;
using DataExplorer.Domain.Tests.Maps.SizeMaps;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Legends.Sizes.Factories
{
    [TestFixture]
    public class StringSizeLegendFactoryTests
    {
        private StringSizeLegendFactory _factory;
        private FakeSizeMap _sizeMap;
        private List<string> _values;
        private string _value;
        private double _size;
        private double _lowerSize;
        private double _upperSize;

        [SetUp]
        public void SetUp()
        {
            _values = new List<string>();
            _value = "A";
            _size = 0d;
            _lowerSize = 0d;
            _upperSize = 1d;

            _sizeMap = new FakeSizeMap(SortOrder.Ascending, _size, _value);

            _factory = new StringSizeLegendFactory();
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
                _values.Add(Convert.ToChar(65 + i).ToString());

            var results = _factory.Create(_sizeMap, _values, _lowerSize, _upperSize);
            Assert.That(results.Count(), Is.EqualTo(expectedItemCount));
        }
    }
}
