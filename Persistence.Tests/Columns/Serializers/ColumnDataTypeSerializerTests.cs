using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using DataExplorer.Persistence.Columns.Serializers;
using DataExplorer.Persistence.Common.Serializers;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Persistence.Tests.Columns.Serializers
{
    [TestFixture]
    public class ColumnDataTypeSerializerTests
    {
        private ColumnDataTypeSerializer _serializer;
        private Mock<IDataTypeSerializer> _mockDataTypeSerializer;
        private XElement _xColumnSet;
        
        [SetUp]
        public void SetUp()
        {
            _mockDataTypeSerializer = new Mock<IDataTypeSerializer>();

            _serializer = new ColumnDataTypeSerializer(
                _mockDataTypeSerializer.Object);
        }

        [Test]
        [TestCase("Boolean", typeof(Boolean), typeof(Boolean?))]
        [TestCase("DateTime", typeof(DateTime), typeof(DateTime?))]
        [TestCase("Float", typeof(Double), typeof(Double?))]
        [TestCase("Integer", typeof(Int32), typeof(Int32?))]
        [TestCase("String", typeof(String), typeof(String))]
        [TestCase("Image", typeof(BitmapImage), typeof(BitmapImage))]
        public void TestDeserializeReturnsNullableType(string dataTypeTag, Type dataType, Type nullableDataType)
        {
            var xDataType = new XElement("data-type", dataTypeTag);

            _xColumnSet = new XElement("column-set",
                new XElement("column", xDataType));

            _mockDataTypeSerializer.Setup(p => p.Deserialize(xDataType))
                .Returns(dataType);

            var result = _serializer.Deserialize(_xColumnSet);
            Assert.That(result, Has.Member(nullableDataType));
        }
    }
}
