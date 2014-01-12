using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Infrastructure.Serializers.Columns;
using DataExplorer.Infrastructure.Serializers.Properties;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Infrastructure.Tests.Serializers.Columns
{
    [TestFixture]
    public class ColumnSerializerTests
    {
        private ColumnSerializer _serializer;
        private Mock<IPropertySerializer> _mockPropertySerializer;
        private Column _column;
        private List<Row> _rows; 

        private XElement _xColumn;
        private XElement _xId;
        private XElement _xIndex;
        private XElement _xName;
        private XElement _xType;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder()
                .WithId(1)
                .WithIndex(0)
                .WithName("Test")
                .WithType(typeof(object))
                .Build();

            _rows = new List<Row>();

            _xColumn = new XElement("column");
            _xId = new XElement("id", _column.Id);
            _xIndex = new XElement("index", _column.Index);
            _xName = new XElement("name", _column.Name);
            _xType = new XElement("type", _column.Type);

            _xColumn.Add(new object[] { _xId, _xIndex, _xName, _xType });
            
            _mockPropertySerializer = new Mock<IPropertySerializer>();
            _mockPropertySerializer.Setup(p => p.Serialize("id", _column.Id)).Returns(_xId);
            _mockPropertySerializer.Setup(p => p.Serialize("index", _column.Index)).Returns(_xIndex);
            _mockPropertySerializer.Setup(p => p.Serialize("name", _column.Name)).Returns(_xName);
            _mockPropertySerializer.Setup(p => p.Serialize("type", _column.Type)).Returns(_xType);
            _mockPropertySerializer.Setup(p => p.Deserialize<int>(_xId)).Returns(_column.Id);
            _mockPropertySerializer.Setup(p => p.Deserialize<int>(_xIndex)).Returns(_column.Index);
            _mockPropertySerializer.Setup(p => p.Deserialize<string>(_xName)).Returns(_column.Name);
            _mockPropertySerializer.Setup(p => p.Deserialize<Type>(_xType)).Returns(_column.Type);

            _serializer = new ColumnSerializer(_mockPropertySerializer.Object);
        }

        [Test]
        public void TestSerializeShouldSerializeId()
        {
            var result = _serializer.Serialize(_column);
            AssertValue(result, "id", _column.Id.ToString());
        }

        [Test]
        public void TestSerializeShouldSerializeIndex()
        {
            var result = _serializer.Serialize(_column);
            AssertValue(result, "index", _column.Index.ToString());
        }

        [Test]
        public void TestSerializeShouldSerializeName()
        {
            var result = _serializer.Serialize(_column);
            AssertValue(result, "name", _column.Name);
        }

        [Test]
        public void TestSerializeShouldSerializeType()
        {
            var result = _serializer.Serialize(_column);
            AssertValue(result, "type", _column.Type.ToString());
        }
        
        private void AssertValue(XElement result, string name, string value)
        {
            var actual = result.Elements()
                .Single(p => p.Name.LocalName == name).Value;
            Assert.That(actual, Is.EqualTo(value));
        }

        [Test]
        public void TestDeserializeShouldDeserializeId()
        {
            var result = _serializer.Deserialize(_xColumn, _rows);
            Assert.That(result.Id, Is.EqualTo(_column.Id));
        }

        [Test]
        public void TestDeserializeShouldDeserializeIndex()
        {
            var result = _serializer.Deserialize(_xColumn, _rows);
            Assert.That(result.Index, Is.EqualTo(_column.Index));
        }

        [Test]
        public void TestDeserializeShouldDeserializeName()
        {
            var result = _serializer.Deserialize(_xColumn, _rows);
            Assert.That(result.Name, Is.EqualTo(_column.Name));
        }

        [Test]
        public void TestDeserializeShouldDeserializeType()
        {
            var result = _serializer.Deserialize(_xColumn, _rows);
            Assert.That(result.Type, Is.EqualTo(_column.Type));
        }
    }
}
