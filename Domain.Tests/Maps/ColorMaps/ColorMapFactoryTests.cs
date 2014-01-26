using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Maps.ColorMaps;
using DataExplorer.Domain.Tests.Colors;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Maps.ColorMaps
{
    [TestFixture]
    public class ColorMapFactoryTests
    {
        private ColorMapFactory _factory;
        
        [SetUp]
        public void SetUp()
        {
            _factory = new ColorMapFactory();
        }

        [Test]
        public void TestCreateAxisMapForInvalidDataTypeShouldThrowArgumentException()
        {
            var column = new ColumnBuilder().WithType(typeof(Object)).Build();

            var colorPalette = new ColorPaletteBuilder().Build();

            Assert.That(() => _factory.Create(column, colorPalette), 
                Throws.ArgumentException);
        }

        [Test]
        public void TestCreateShouldCreateBooleanToColorMap()
        {
            AssertResult<Boolean>(typeof(BooleanToColorMap));
        }

        [Test]
        public void TestCreateShouldCreateDateTimeToColorMap()
        {
            AssertResult<DateTime>(typeof(DateTimeToColorMap));
        }

        [Test]
        public void TestCreateShouldCreateFloatToColorMap()
        {
            AssertResult<Double>(typeof(FloatToColorMap));
        }

        [Test]
        public void TestCreateShouldCreateIntegerToColorMap()
        {
            AssertResult<Int32>(typeof(IntegerToColorMap));
        }

        [Test]
        public void TestCreateShouldCreateStringToColorMap()
        {
            AssertResult<String>(typeof(StringToColorMap));
        }

        private void AssertResult<T>(Type mapType)
        {
            var column = new ColumnBuilder()
                .WithValue(default(T))
                .WithType(typeof(T))
                .Build();

            var colorPalette = new ColorPaletteBuilder().Build();
            
            var result = _factory.Create(column, colorPalette);
            
            Assert.That(result, Is.TypeOf(mapType));
        }
    }
}
