using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Maps.LabelMaps;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Maps.LabelMaps
{
    [TestFixture]
    public class LabelMapFactoryTests
    {
        private LabelMapFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new LabelMapFactory();
        }

        [Test]
        public void TestCreateLabelMapForInvalidDataTypeShouldThrowArgumentException()
        {
            var column = new ColumnBuilder().WithType(typeof(Object)).Build();
            Assert.That(() => _factory.Create(column), Throws.ArgumentException);
        }

        [Test]
        public void TestCreateShouldReturnABooleanToLabelMap()
        {
            AssertResult<Boolean>(typeof(BooleanToLabelMap));
        }

        [Test]
        public void TestCreateShouldReturnADateTimeToLabelMap()
        {
            AssertResult<DateTime>(typeof(DateTimeToLabelMap));
        }

        [Test]
        public void TestCreateShouldReturnAFloatToLabelMap()
        {
            AssertResult<Double>(typeof(FloatToLabelMap));
        }

        [Test]
        public void TestCreateShouldReturnAnIntegerToLabelMap()
        {
            AssertResult<Int32>(typeof(IntegerToLabelMap));
        }

        [Test]
        public void TestCreateShouldReturnAStringToLabelMap()
        {
            AssertResult<String>(typeof(StringToLabelMap));
        }

        private void AssertResult<T>(Type mapType)
        {
            var column = new ColumnBuilder()
                .WithValue(default(T))
                .WithType(typeof(T))
                .Build();
            var result = _factory.Create(column);
            Assert.That(result, Is.TypeOf(mapType));
        }
    }
}
