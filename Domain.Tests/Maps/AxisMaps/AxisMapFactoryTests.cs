using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Maps.AxisMaps
{
    [TestFixture]
    public class AxisMapFactoryTests
    {
        private AxisMapFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new AxisMapFactory();
        }

        [Test]
        public void TestCreateAxisMapForInvalidDataTypeShouldThrowArgumentException()
        {
            var column = new ColumnBuilder().WithType(typeof(Object)).Build();
            Assert.That(() => _factory.Create(column, 0d, 1d), Throws.ArgumentException);
        }

        [Test]
        public void TestCreateShouldReturnABooleanToAxisMap()
        {
            AssertResult<Boolean>(typeof(BooleanToAxisMap));
        }

        [Test]
        public void TestCreateShouldReturnADateTimeToAxisMap()
        {
            AssertResult<DateTime>(typeof(DateTimeToAxisMap));
        }

        [Test]
        public void TestCreateShouldReturnAFloatToAxisMap()
        {
            AssertResult<Double>(typeof(FloatToAxisMap));
        }

        [Test]
        public void TestCreateShouldReturnAnIntegerToAxisMap()
        {
            AssertResult<Int32>(typeof(IntegerToAxisMap));
        }

        [Test]
        public void TestCreateShouldReturnAStringToAxisMap()
        {
            AssertResult<String>(typeof(StringToAxisMap));
        }

        private void AssertResult<T>(Type mapType)
        {
            var column = new ColumnBuilder()
                .WithValue(default(T))
                .WithType(typeof(T))
                .Build();
            var result = _factory.Create(column, 0d, 1d);
            Assert.That(result, Is.TypeOf(mapType));
        }
    }
}
