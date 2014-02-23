using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Persistence.Columns.Serializers;
using DataExplorer.Persistence.Projects;
using DataExplorer.Persistence.Tests.Projects;
using NUnit.Framework;

namespace DataExplorer.Persistence.Tests.Columns.Serializers
{
    [TestFixture]
    public class ColumnSerializerTests : SerializerTests
    {
        private ColumnSerializer _serializer;
        private Column _column;
        private List<Row> _rows; 
        private XElement _xColumn;


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

            _xColumn = new XElement("column",
                new XElement("id", _column.Id),
                new XElement("index", _column.Index),
                new XElement("name", _column.Name),
                new XElement("type", _column.Type));

            _serializer = new ColumnSerializer(
                new PropertySerializer());
        }

        [Test]
        public void TestSerializeShouldSerializeId()
        {
            var result = _serializer.Serialize(_column);
            AssertValue(result, "id", _column.Id.ToString());
            AssertValue(result, "index", _column.Index.ToString());
            AssertValue(result, "name", _column.Name);
            AssertValue(result, "type", _column.Type.ToString());
        }
        
        [Test]
        public void TestDeserializeShouldDeserializeId()
        {
            var result = _serializer.Deserialize(_xColumn, _rows);
            Assert.That(result.Id, Is.EqualTo(_column.Id));
            Assert.That(result.Index, Is.EqualTo(_column.Index));
            Assert.That(result.Name, Is.EqualTo(_column.Name));
            Assert.That(result.Type, Is.EqualTo(_column.Type));
        }
    }
}
