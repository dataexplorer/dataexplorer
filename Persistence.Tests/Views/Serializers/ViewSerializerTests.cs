﻿using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Tests.Views;
using DataExplorer.Domain.Tests.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Persistence.Views.Serializers;
using DataExplorer.Persistence.Views.Serializers.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Persistence.Tests.Views.Serializers
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
            _scatterPlot = new ScatterPlotBuilder().Build();
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
