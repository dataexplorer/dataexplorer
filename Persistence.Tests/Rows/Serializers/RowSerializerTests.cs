using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.Rows;
using DataExplorer.Persistence.Projects;
using DataExplorer.Persistence.Rows.Serializers;
using NUnit.Framework;

namespace DataExplorer.Persistence.Tests.Rows.Serializers
{
    [TestFixture]
    public class RowSerializerTests
    {
        private RowSerializer _serializer;
        private Column _column;
        private List<Column> _columns;
        private List<Type> _dataTypes; 
        private Row _row;
        private XElement _xRow;

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

            _xRow = new XElement("row",
                new XElement("id", _row.Id),
                new XElement("fields",
                    new XElement("column-1", "Field 1")));

            _serializer = new RowSerializer(
                new PropertySerializer());
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
