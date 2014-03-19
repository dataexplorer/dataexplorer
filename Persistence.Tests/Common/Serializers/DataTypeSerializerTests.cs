using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using DataExplorer.Persistence.Common.Serializers;
using NUnit.Framework;

namespace DataExplorer.Persistence.Tests.Common.Serializers
{
    [TestFixture]
    public class DataTypeSerializerTests
    {
        private DataTypeSerializer _serializer;

        [SetUp]
        public void SetUp()
        {
            _serializer = new DataTypeSerializer();
        }

        [Test]
        [TestCase(typeof (Boolean), "Boolean")]
        [TestCase(typeof(DateTime), "DateTime")]
        [TestCase(typeof(Double), "Float")]
        [TestCase(typeof(Int32), "Integer")]
        [TestCase(typeof(String), "Text")]
        [TestCase(typeof(BitmapImage), "Image")]
        public void TestSerializeShouldSerializeTypes(Type type, string tag)
        {
            var result = _serializer.Serialize("data-type", type);
            Assert.That(result.Value, Is.EqualTo(tag));
        }

        [Test]
        [TestCase("Boolean", typeof(Boolean))]
        [TestCase("DateTime", typeof(DateTime))]
        [TestCase("Float", typeof(Double))]
        [TestCase("Integer", typeof(Int32))]
        [TestCase("Text", typeof(String))]
        [TestCase("Image", typeof(BitmapImage))]
        public void TestSerializeShouldSerializeTypes(string tag, Type type)
        {
            var xProperty = new XElement("data-type", tag);
            var result = _serializer.Deserialize(xProperty);
            Assert.That(result, Is.EqualTo(type));
        }
    }
}
