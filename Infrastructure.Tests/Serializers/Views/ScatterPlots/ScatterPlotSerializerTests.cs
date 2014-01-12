using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Infrastructure.Serializers.Properties;
using DataExplorer.Infrastructure.Serializers.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Infrastructure.Tests.Serializers.Views.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotSerializerTests
    {
        private ScatterPlotSerializer _serializer;
        private Mock<IPropertySerializer> _mockExtentSerializer;
        private Mock<IScatterPlotLayoutSerializer> _mockLayoutSerializer;
        private ScatterPlot _scatterPlot;
        private ScatterPlotLayout _layout;
        private Rect _extent;
        private List<Column> _columns;
        private XElement _xScatterPlot;
        private XElement _xLayout;
        private XElement _xExtent;

        [SetUp]
        public void SetUp()
        {
            _layout = new ScatterPlotLayout();
            _extent = new Rect();
            _scatterPlot = new ScatterPlot(_layout, _extent, new List<Plot>());
            _columns = new List<Column>();

            _xScatterPlot = new XElement("scatter-plot");
            _xLayout = new XElement("layout");
            _xExtent = new XElement("extent");
            _xScatterPlot.Add(_xLayout, _xExtent);

            _mockLayoutSerializer = new Mock<IScatterPlotLayoutSerializer>();
            _mockLayoutSerializer.Setup(p => p.Serialize(_layout)).Returns(_xLayout);
            _mockLayoutSerializer.Setup(p => p.Deserialize(_xLayout, _columns)).Returns(_layout);

            _mockExtentSerializer = new Mock<IPropertySerializer>();
            _mockExtentSerializer.Setup(p => p.Serialize("extent", _extent)).Returns(_xExtent);
            _mockExtentSerializer.Setup(p => p.Deserialize<Rect>(_xExtent)).Returns(_extent);
            
            _serializer = new ScatterPlotSerializer(
                _mockExtentSerializer.Object,
                _mockLayoutSerializer.Object);
        }

        [Test]
        public void TestSerializeShouldSerializeView()
        {
            var result = _serializer.Serialize(_scatterPlot);
            AssertValue(result, "layout", _xLayout);
            AssertValue(result, "extent", _xExtent);
        }

        private void AssertValue(XElement result, string name, object value)
        {
            Assert.That(result.Elements().Single(p => p.Name.LocalName == name).ToString(),
                Is.EqualTo(value.ToString()));
        }

        [Test]
        public void TestDeserializeShouldDeserializeView()
        {
            var result = _serializer.Deserialize(_xScatterPlot, _columns);
            Assert.That(result.GetLayout(), Is.EqualTo(_layout));
            Assert.That(result.GetViewExtent(), Is.EqualTo(_extent));
        }
    }
}
