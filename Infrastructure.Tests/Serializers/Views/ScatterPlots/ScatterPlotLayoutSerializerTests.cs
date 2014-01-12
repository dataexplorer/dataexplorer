using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Infrastructure.Serializers.Properties;
using DataExplorer.Infrastructure.Serializers.Views.ScatterPlots;
using DataExplorer.Tests.Domain.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Infrastructure.Serializers.Views.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotLayoutSerializerTests
    {
        private ScatterPlotLayoutSerializer _serializer;
        private Mock<IPropertySerializer> _mockPropertySerializer;
        private ScatterPlotLayout _layout;
        private List<Column> _columns; 
        private Column _xAxisColumn;
        private Column _yAxisColumn;
        private XElement _xLayout;
        private XElement _xXAxisColumnId;
        private XElement _xYAxisColumnId;

        [SetUp]
        public void SetUp()
        {
            _xAxisColumn = new ColumnBuilder().WithId(1).Build();
            _yAxisColumn = new ColumnBuilder().WithId(2).Build();

            _columns = new List<Column> { _xAxisColumn, _yAxisColumn };

            _layout = new ScatterPlotLayout
            {
                XAxisColumn = _xAxisColumn,
                YAxisColumn = _yAxisColumn
            };

            _xLayout = new XElement("layout");
            _xXAxisColumnId = new XElement("x-axis-column-id", 1);
            _xYAxisColumnId = new XElement("y-axis-column-id", 2);
            _xLayout.Add(_xXAxisColumnId, _xYAxisColumnId);

            _mockPropertySerializer = new Mock<IPropertySerializer>();
            _mockPropertySerializer.Setup(p => p.Serialize<int?>("x-axis-column-id", 1)).Returns(_xXAxisColumnId);
            _mockPropertySerializer.Setup(p => p.Serialize<int?>("y-axis-column-id", 2)).Returns(_xYAxisColumnId);
            _mockPropertySerializer.Setup(p => p.Deserialize<int?>(_xXAxisColumnId)).Returns(1);
            _mockPropertySerializer.Setup(p => p.Deserialize<int?>(_xYAxisColumnId)).Returns(2);
            
            _serializer = new ScatterPlotLayoutSerializer(_mockPropertySerializer.Object);
        }

        [Test]
        public void TestSerializeShouldSerializeLayout()
        {
            var result = _serializer.Serialize(_layout);
            AssertValue(result, "x-axis-column-id", "1");
            AssertValue(result, "y-axis-column-id", "2");
        }

        private void AssertValue(XElement result, string name, object value)
        {
            Assert.That(result.Elements().First(p => p.Name.LocalName == name).Value, 
                Is.EqualTo(value));
        }

        [Test]
        public void TestDeserializeShoulDeserializeLayout()
        {
            var result = _serializer.Deserialize(_xLayout, _columns);
            Assert.That(result.XAxisColumn, Is.EqualTo(_xAxisColumn));
            Assert.That(result.YAxisColumn, Is.EqualTo(_yAxisColumn));
        }
    }
}
