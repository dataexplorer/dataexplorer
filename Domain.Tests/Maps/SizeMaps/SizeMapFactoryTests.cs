using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.SizeMaps;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Maps.SizeMaps
{
    [TestFixture]
    public class SizeMapFactoryTests
    {
        private SizeMapFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new SizeMapFactory();
        }

        [Test]
        public void TestCreateSizeMapForInvalidDataTypeShouldThrowArgumentException()
        {
            var column = new ColumnBuilder().WithDataType(typeof(Object)).Build();
            Assert.That(() => _factory.Create(column, 0d, 1d, SortOrder.Ascending), Throws.ArgumentException);
        }

        [Test]
        public void TestCreateShouldReturnABooleanToSizeMap()
        {
            AssertResult<Boolean>(typeof(BooleanToSizeMap));
        }

        [Test]
        public void TestCreateShouldReturnADateTimeToSizeMap()
        {
            AssertResult<DateTime>(typeof(DateTimeToSizeMap));
        }

        [Test]
        public void TestCreateShouldReturnAFloatToSizeMap()
        {
            AssertResult<Double>(typeof(FloatToSizeMap));
        }

        [Test]
        public void TestCreateShouldReturnAnIntegerToSizeMap()
        {
            AssertResult<Int32>(typeof(IntegerToSizeMap));
        }

        [Test]
        public void TestCreateShouldReturnAStringToSizeMap()
        {
            AssertResult<String>(typeof(StringToSizeMap));
        }

        private void AssertResult<T>(Type mapType)
        {
            var column = new ColumnBuilder()
                .WithValue(default(T))
                .WithDataType(typeof(T))
                .Build();
            var result = _factory.Create(column, 0d, 1d, SortOrder.Ascending);
            Assert.That(result, Is.TypeOf(mapType));
        }
    }
}
