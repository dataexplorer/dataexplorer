using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Tests.Domain.Columns;
using DataExplorer.Tests.Domain.Rows;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotRendererTests
    {
        private ScatterPlotRenderer _renderer;
        private Mock<IMapFactory> _mockMapFactory;

        [SetUp]
        public void SetUp()
        {
            _mockMapFactory = new Mock<IMapFactory>();
            _renderer = new ScatterPlotRenderer(_mockMapFactory.Object);
        }

        [Test]
        public void TestRenderPlotsShouldRenderRowsIntoPlots()
        {
            var row = new RowBuilder().WithFields(0.5d, 1d).Build();
            var rows = new List<Row> { row };
            var layout = new ScatterPlotLayout();
            layout.XAxisColumn = new ColumnBuilder().WithIndex(0).Build();
            layout.YAxisColumn = new ColumnBuilder().WithIndex(1).Build();
            var map = new FloatToAxisMap(0d, 1d, 0d, 1d);
            _mockMapFactory.Setup(p => p.CreateAxisMap(layout.XAxisColumn, 0d, 1d)).Returns(map);
            _mockMapFactory.Setup(p => p.CreateAxisMap(layout.YAxisColumn, 0d, 1d)).Returns(map);
            var results = _renderer.RenderPlots(rows, layout);
            Assert.That(results.Single().X, Is.EqualTo(0.5d));
            Assert.That(results.Single().Y, Is.EqualTo(1.0d));
        }
    }
}
