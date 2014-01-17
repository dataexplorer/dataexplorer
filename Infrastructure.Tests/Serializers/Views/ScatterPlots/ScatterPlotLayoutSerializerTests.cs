using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Infrastructure.Serializers.Properties;
using DataExplorer.Infrastructure.Serializers.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Infrastructure.Tests.Serializers.Views.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotLayoutSerializerTests
    {
        private ScatterPlotLayoutSerializer _serializer;
        private ScatterPlotLayout _layout;
        private List<Column> _columns; 
        private Column _xAxisColumn;
        private Column _yAxisColumn;
        private XElement _xLayout;

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

            _xLayout = new XElement("layout",
                new XElement("x-axis-column-id", 1),
                new XElement("y-axis-column-id", 2));
           
            _serializer = new ScatterPlotLayoutSerializer(
                new PropertySerializer());
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
