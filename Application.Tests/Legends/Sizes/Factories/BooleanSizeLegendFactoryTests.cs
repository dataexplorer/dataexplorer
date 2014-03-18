using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Legends.Sizes;
using DataExplorer.Application.Legends.Sizes.Factories;
using DataExplorer.Domain.Maps.SizeMaps;
using DataExplorer.Domain.Tests.Maps;
using DataExplorer.Domain.Tests.Maps.SizeMaps;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Legends.Sizes.Factories
{
    [TestFixture]
    public class BooleanSizeLegendFactoryTests
    {
        private BooleanSizeLegendFactory _factory;
        private SizeMap _sizeMap;
        private List<bool?> _values;
        private double _lowerSize;
        private double _upperSize;
        
        [SetUp]
        public void SetUp()
        {
            _sizeMap = new FakeSizeMap();
            _values = new List<bool?>();
            _lowerSize = 0d;
            _upperSize = 1d;

            _factory = new BooleanSizeLegendFactory();
        }

        [Test]
        public void TestCreateShouldReturnSizeLegendItems()
        {
            var results = _factory.Create(_sizeMap, _values, _lowerSize, _upperSize);
            AssertResult(results.First(), _lowerSize, "False");
            AssertResult(results.Last(), _upperSize, "True");
        }

        private void AssertResult(SizeLegendItemDto itemDto, double size, string label)
        {
            Assert.That(itemDto.Size, Is.EqualTo(size));
            Assert.That(itemDto.Label, Is.EqualTo(label));
        }
    }
}
