using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Infrastructure.Serializers.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Infrastructure.Tests.Serializers.Columns
{
    [TestFixture]
    public class ColumnSetSerializerTests
    {
        private ColumnSetSerializer _serializer;
        private Mock<IColumnSerializer> _mockColumnSerializer;
        private List<Column> _columns;
        private Column _column;
        private List<Row> _rows; 
        private XElement _xColumns;
        private XElement _xColumn;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();
            _columns = new List<Column> { _column };
            _rows = new List<Row>();

            _xColumn = new XElement("column");
            _xColumns = new XElement("columns");
            _xColumns.Add(_xColumn);

            _mockColumnSerializer = new Mock<IColumnSerializer>();
            _mockColumnSerializer.Setup(p => p.Serialize(_column)).Returns(_xColumn);
            _mockColumnSerializer.Setup(p => p.Deserialize(_xColumn, _rows)).Returns(_column);

            _serializer = new ColumnSetSerializer(_mockColumnSerializer.Object);
        }

        [Test]
        public void TestSerializeShouldReturnSerializedColumns()
        {
            var result = _serializer.Serialize(_columns);
            Assert.That(result.Name, Is.EqualTo(_xColumns.Name));
            Assert.That(result.Elements().Single().Name, Is.EqualTo(_xColumn.Name));
        }

        [Test]
        public void TestDeserializeShouldReturnDeserializedColumns()
        {
            var result = _serializer.Deserialize(_xColumns, _rows);
            Assert.That(result.Single(), Is.EqualTo(_column));
        }
    }
}
