using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Infrastructure.Serializers.Properties;
using NUnit.Framework;

namespace DataExplorer.Infrastructure.Tests.Serializers.Properties
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

            _serializer = new PropertySerializer();
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
        public void TestSerializeShouldSerializeType()
        {
            var result = _serializer.Serialize(_name, typeof(object));
            Assert.That(result.Value, Is.EqualTo("System.Object"));
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
        public void TestDeserializeShouldDeserializeType()
        {
            AssertDeserialization(typeof(object), typeof(Type));
        }

        private void AssertDeserialization(object value, Type type)
        {
            var xProperty = new XElement("Name", value);
            var result = _serializer.Deserialize(xProperty, type);
            Assert.That(result, Is.EqualTo(value));
        }
    }
}
