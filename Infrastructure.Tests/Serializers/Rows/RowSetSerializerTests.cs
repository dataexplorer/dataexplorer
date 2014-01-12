using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Tests.Rows;
using DataExplorer.Infrastructure.Serializers.Rows;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Infrastructure.Tests.Serializers.Rows
{
    [TestFixture]
    public class RowSetSerializerTests
    {
        private RowSetSerializer _serializer;
        private Mock<IRowSerializer> _mockRowSerializer;
        private List<Column> _columns;
        private List<Row> _rows;
        private Row _row;
        private List<Type> _dataTypes;
        private XElement _xRows;
        private XElement _xRow;

        [SetUp]
        public void SetUp()
        {
            _columns = new List<Column>();
            _row = new RowBuilder().Build();
            _rows = new List<Row> { _row };
            _dataTypes = new List<Type>();

            _xRow = new XElement("row");
            _xRows = new XElement("rows");
            _xRows.Add(_xRow);

            _mockRowSerializer = new Mock<IRowSerializer>();
            _mockRowSerializer.Setup(p => p.Serialize(_row, _columns)).Returns(_xRow);
            _mockRowSerializer.Setup(p => p.Deserialize(_xRow, _dataTypes)).Returns(_row);

            _serializer = new RowSetSerializer(_mockRowSerializer.Object);
        }

        [Test]
        public void TestSerializeShouldReturnSerializedRows()
        {
            var result = _serializer.Serialize(_rows, _columns);
            Assert.That(result.Name, Is.EqualTo(_xRows.Name));
            Assert.That(result.Elements().Single().Name, Is.EqualTo(_xRow.Name));
        }

        [Test]
        public void TestDeserializeShouldReturnDeserializedRows()
        {
            var result = _serializer.Deserialize(_xRows, _dataTypes);
            Assert.That(result.Single(), Is.EqualTo(_row));
        }
    }
}
