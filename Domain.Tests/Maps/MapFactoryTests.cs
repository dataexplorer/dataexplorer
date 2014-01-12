using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.Maps
{
    [TestFixture]
    public class MapFactoryTests
    {
        private MapFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new MapFactory();
        }

        [Test]
        public void TestCreateAxisMapForFloatShouldReturnAFloatToAxisMap()
        {
            var column = new ColumnBuilder()
                .WithType(typeof(Double))
                .WithValue(0d)
                .WithValue(1d)
                .Build();
            var result = _factory.CreateAxisMap(column, 0d, 1d);
            Assert.That(result, Is.TypeOf<FloatToAxisMap>());
        }

        [Test]
        public void TestCreateAxisMapForBooleanShouldReturnABooleanToAxisMap()
        {
            var column = new ColumnBuilder()
                .WithType(typeof(Boolean))
                .WithValue(0d)
                .WithValue(1d)
                .Build();
            var result = _factory.CreateAxisMap(column, 0d, 1d);
            Assert.That(result, Is.TypeOf<BooleanToAxisMap>());
        }

        [Test]
        public void TestCreateAxisMapForInvalidDataTypeShouldThrowArgumentException()
        {
            var column = new ColumnBuilder().WithType(typeof(Object)).Build();
            Assert.That(() => _factory.CreateAxisMap(column, 0d, 1d), Throws.ArgumentException);
        }
    }
}
