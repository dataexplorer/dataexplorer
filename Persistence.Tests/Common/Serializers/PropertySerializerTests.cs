using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using DataExplorer.Domain.Semantics;
using DataExplorer.Persistence.Common.Serializers;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Persistence.Tests.Common.Serializers
{
    [TestFixture]
    public class PropertySerializerTests
    {
        private PropertySerializer _serializer;
        private string _name;

        [SetUp]
        public void SetUp()
        {
            _name = "PropertyName";

            _serializer = new PropertySerializer(
                new DataTypeSerializer());
        }

        [Test]
        public void TestSerializeShouldSerializeList()
        {
            var values = new List<bool> {true};
            var result = _serializer.SerializeList("list", values);
            Assert.That(result.Elements().Single().Value, Is.EqualTo("true"));
        }

        [Test]
        public void TestSerializeShouldSerializeName()
        {
            var result = _serializer.Serialize(_name, new object());
            Assert.That(result.Name.LocalName, Is.EqualTo(_name));
        }

        [Test]
        public void TestSerializeShouldSerializeNull()
        {
            var result = _serializer.Serialize(_name, (object) null);
            Assert.That(result.Value, Is.EqualTo(string.Empty));
        }

        [Test]
        public void TestSerializeShouldSerializeBoolean()
        {
            var result = _serializer.Serialize(_name, true);
            Assert.That(result.Value, Is.EqualTo("true"));
        }

        [Test]
        public void TestSerializeShouldSerializeDateTime()
        {
            var result = _serializer.Serialize(_name, new DateTime(2001, 01, 01));
            Assert.That(result.Value, Is.EqualTo("2001-01-01T00:00:00"));
        }

        [Test]
        public void TestSerializeShouldSerializeFloat()
        {
            var result = _serializer.Serialize(_name, 1.23d);
            Assert.That(result.Value, Is.EqualTo("1.23"));
        }

        [Test]
        public void TestSerializeShouldSerializeInteger()
        {
            var result = _serializer.Serialize(_name, 123);
            Assert.That(result.Value, Is.EqualTo("123"));
        }

        [Test]
        public void TestSerializeShouldSerializeString()
        {
            var result = _serializer.Serialize(_name, "Test");
            Assert.That(result.Value, Is.EqualTo("Test"));
        }

        [Test]
        public void TestSerializeShouldSerializeNullImage()
        {
            var result = _serializer.Serialize(_name, (BitmapImage) null);
            Assert.That(result.Value, Is.Empty);
        }

        [Test]
        public void TestSerializeShouldSerializeImage()
        {
            var image = CreateImage();
            var result = _serializer.Serialize("Name", image);
            var expected = _serializer.Deserialize(result, typeof(BitmapImage));
            Assert.That(((BitmapImage) expected).PixelHeight, Is.EqualTo(image.PixelHeight));
            Assert.That(((BitmapImage) expected).PixelWidth, Is.EqualTo(image.PixelWidth));
        }

        [Test]
        public void TestSerializeShouldSerializeEnum()
        {
            var result = _serializer.Serialize(_name, SemanticType.Measure);
            Assert.That(result.Value, Is.EqualTo("Measure"));
        }

        [Test]
        public void TestSerializeShouldSerializeRect()
        {
            var result = _serializer.Serialize(_name, new Rect(1, 2, 3, 4));
            Assert.That(result.Value, Is.EqualTo("1,2,3,4"));
        }

        [Test]
        public void TestSerializeShouldSerializeType()
        {
            var result = _serializer.Serialize(_name, typeof(Boolean));
            Assert.That(result.Value, Is.EqualTo("Boolean"));
        }

        [Test]
        public void TestDeserializeShouldDeserializeList()
        {
            var xItem = new XElement("value", true);
            var xList = new XElement("list", xItem);
            var result = _serializer.DeserializeList<bool>(xList);
            Assert.That(result.Single(), Is.EqualTo(true));
        }

        [Test]
        public void TestDeserializeShouldDeserializeBoolean()
        {
            AssertDeserialization(true, typeof(bool));
        }

        [Test]
        public void TestDeserializeShouldDeserializeDateTime()
        {
            AssertDeserialization(new DateTime(2001, 01, 01), typeof(DateTime));
        }

        [Test]
        public void TestDeserializeShouldDeserializeInteger()
        {
            AssertDeserialization(123, typeof(int));
        }

        [Test]
        public void TestDeserializeShouldDeserializeFloat()
        {
            AssertDeserialization(1.23d, typeof(double));
        }

        [Test]
        public void TestDeserializeShouldDeserializeString()
        {
            AssertDeserialization("Test", typeof(string));
        }

        [Test]
        public void TestDeserializeShouldDeserializeNullImage()
        {
            var xProperty = new XElement("Name", string.Empty);
            var result = _serializer.Deserialize(xProperty, typeof(BitmapImage));
            Assert.That(result, Is.Null);
        }

        [Test]
        public void TestDeserializeShouldDeserializeImage()
        {
            var image = CreateImage();
            var xProperty = _serializer.Serialize("Name", image);
            var result = _serializer.Deserialize(xProperty, typeof(BitmapImage));
            Assert.That(((BitmapImage) result).PixelHeight, Is.EqualTo(image.PixelHeight));
            Assert.That(((BitmapImage)result).PixelWidth, Is.EqualTo(image.PixelWidth));
        }

        [Test]
        public void TestDeserializeShouldDeserializeRect()
        {
            AssertDeserialization(new Rect(1, 2, 3, 4), typeof(Rect));
        }

        [Test]
        public void TestDeserializeShouldDeserializeEnum()
        {
            AssertDeserialization(SemanticType.Measure, typeof(SemanticType));
        }

        [Test]
        public void TestDeserializeShouldDeserializeType()
        {
            var xProperty = new XElement("Name", "Boolean");
            var result = _serializer.Deserialize(xProperty, typeof(Type));
            Assert.That(result, Is.EqualTo(typeof(Boolean)));
        }

        private void AssertDeserialization(object value, Type type)
        {
            var xProperty = new XElement("Name", value);
            var result = _serializer.Deserialize(xProperty, type);
            Assert.That(result, Is.EqualTo(value));
        }

        private BitmapImage CreateImage()
        {
            var bitmap = new Bitmap(128, 128);
            var stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Bmp);

            var image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();

            return image;
        }
    }
}
