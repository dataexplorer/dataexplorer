using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Infrastructure.Serializers.Views;
using DataExplorer.Infrastructure.Serializers.Views.ScatterPlots;
using DataExplorer.Tests.Domain.Views;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Infrastructure.Serializers.Views
{
    [TestFixture]
    public class ViewSerializerTests
    {
        private ViewSerializer _serializer;
        private Mock<IScatterPlotSerializer> _mockScatterPlotSerializer;
        private ScatterPlot _scatterPlot;
        private XElement _xScatterPlot;
        private List<Column> _columns;
            
        [SetUp]
        public void SetUp()
        {
            _scatterPlot = new ScatterPlot();
            _xScatterPlot = new XElement("scatter-plot");

            _columns = new List<Column>();

            _mockScatterPlotSerializer = new Mock<IScatterPlotSerializer>();
            _mockScatterPlotSerializer.Setup(p => p.Serialize(_scatterPlot)).Returns(_xScatterPlot);
            _mockScatterPlotSerializer.Setup(p => p.Deserialize(_xScatterPlot, _columns)).Returns(_scatterPlot);

            _serializer = new ViewSerializer(_mockScatterPlotSerializer.Object);
        }

        [Test]
        public void TestSerializeScatterPlotShouldSerializeScatterPlot()
        {
            var result = _serializer.Serialize(_scatterPlot);
            Assert.That(result, Is.EqualTo(_xScatterPlot));
        }

        [Test]
        public void TestSerializeOtherViewShouldThrowException()
        {
            var view = new FakeView();
            Assert.That(() => _serializer.Serialize(view), Throws.ArgumentException);
        }

        [Test]
        public void TestDeserializeScatterPlotShouldDeserializeScatterPlot()
        {
            var result = _serializer.Deserialize(_xScatterPlot, _columns);
            Assert.That(result, Is.EqualTo(_scatterPlot));
        }

        [Test]
        public void TestDeserializeOtherViewViewShouldThrowException()
        {
            var xView = new XElement("other-view");
            Assert.That(() => _serializer.Deserialize(xView, _columns), Throws.ArgumentException);
        }
    }
}
