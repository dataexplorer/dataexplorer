using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.Rows;
using DataExplorer.Infrastructure.Serializers.Properties;
using DataExplorer.Infrastructure.Serializers.Rows;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Infrastructure.Tests.Serializers.Rows
{
    [TestFixture]
    public class RowSerializerTests
    {
        private RowSerializer _serializer;
        private Mock<IPropertySerializer> _mockPropertySerializer;
        private Column _column;
        private List<Column> _columns;
        private List<Type> _dataTypes; 
        private Row _row;
        private XElement _xRow;
        private XElement _xId;
        private XElement _xFields;
        private XElement _xField;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder()
                .WithName("Column 1")
                .WithType(typeof(string))
                .Build();
            _columns = new List<Column> { _column };
            _dataTypes = new List<Type> { typeof(string) };
            _row = new RowBuilder()
                .WithId(1)
                .WithField("Field 1")
                .Build();

            _xRow = new XElement("row");
            _xId = new XElement("id", _row.Id);
            _xField = new XElement("column-1", "Field 1");
            _xFields = new XElement("fields");

            _xFields.Add(_xField);
            _xRow.Add(new object[] { _xId, _xFields });

            _mockPropertySerializer = new Mock<IPropertySerializer>();
            _mockPropertySerializer.Setup(p => p.Serialize("id", _row.Id)).Returns(_xId);
            _mockPropertySerializer.Setup(p => p.Serialize("column-1", _row.Fields.First())).Returns(_xField);
            _mockPropertySerializer.Setup(p => p.Deserialize<int>(_xId)).Returns(_row.Id);
            _mockPropertySerializer.Setup(p => p.Deserialize(_xField, _column.Type)).Returns(_row.Fields.First());
            _serializer = new RowSerializer(_mockPropertySerializer.Object);
        }

        [Test]
        public void TestSerializeShouldSerializeId()
        {
            var result = _serializer.Serialize(_row, _columns);
            var id = result.Elements().Single(p => p.Name == "id").Value;
            Assert.That(id, Is.EqualTo(_row.Id.ToString()));
        }

        [Test]
        public void TestSerializerShouldSerializeFields()
        {
            var result = _serializer.Serialize(_row, _columns);
            var fields = result.Elements().Single(p => p.Name == "fields").Elements().ToList();
            Assert.That(fields[0].Name.LocalName, Is.EqualTo("column-1"));
            Assert.That(fields[0].Value, Is.EqualTo("Field 1"));
        }

        [Test]
        public void TestDeserializeShouldDeserializeId()
        {
            var result = _serializer.Deserialize(_xRow, _dataTypes);
            Assert.That(result.Id, Is.EqualTo(_row.Id));
        }

        [Test]
        public void TestDeserializeShouldDeserializeFields()
        {
            var result = _serializer.Deserialize(_xRow, _dataTypes);
            Assert.That(result.Fields.First(), Is.EqualTo(_row.Fields.First()));
        }
    }
}
