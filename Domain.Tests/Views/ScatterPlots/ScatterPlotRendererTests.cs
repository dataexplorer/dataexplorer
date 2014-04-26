using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Maps.ColorMaps;
using DataExplorer.Domain.Maps.LabelMaps;
using DataExplorer.Domain.Maps.SizeMaps;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Tests.Colors;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.Rows;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Views.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotRendererTests
    {
        private ScatterPlotRenderer _renderer;
        private Mock<IMapFactory> _mockMapFactory;
        private Mock<AxisMap> _mockXAxisMap;
        private Mock<AxisMap> _mockYAxisMap;
        private Mock<ColorMap> _mockColorMap;
        private Mock<SizeMap> _mockSizeMap;
        private Mock<LabelMap> _mockLabelMap;
        private ScatterPlotLayout _layout;
        private ColorPalette _colorPalette;
        private Color _color;
        private Column _column;
        private List<Row> _rows; 
        private Row _row;

        [SetUp]
        public void SetUp()
        {
            _colorPalette = new ColorPaletteBuilder().Build();
            _color = new Color(0, 0, 0);

            _layout = new ScatterPlotLayout();
            _column = new ColumnBuilder().WithIndex(0).Build();
            _row = new RowBuilder().WithId(1).WithField(1.0d).Build();
            _rows = new List<Row> { _row };
            
            _mockXAxisMap = new Mock<AxisMap>();
            _mockYAxisMap = new Mock<AxisMap>();
            _mockColorMap = new Mock<ColorMap>();
            _mockSizeMap = new Mock<SizeMap>();
            _mockLabelMap = new Mock<LabelMap>();

            _mockMapFactory = new Mock<IMapFactory>();
            
            _renderer = new ScatterPlotRenderer(_mockMapFactory.Object);
        }

        [Test]
        public void TestRenderPlotsShouldRenderPlotId()
        {
            var results = _renderer.RenderPlots(_rows, _layout);
            
            Assert.That(results.Single().Id, Is.EqualTo(_row.Id));
        }

        // TODO: Need to separate the render into separate renderers for each mapping
        // TODO: And add additional test cases for each of these mappings

        [Test]
        public void TestRenderPlotsShouldRenderXAxisValue()
        {
            _mockMapFactory.Setup(p => p.CreateAxisMap(_column, 0d, 1d, false))
                .Returns(_mockXAxisMap.Object);
            
            _mockXAxisMap.Setup(p => p.Map(1.0d)).Returns(1.0d);
            
            _layout.XAxisColumn = _column;

            var results = _renderer.RenderPlots(_rows, _layout);

            Assert.That(results.Single().X, Is.EqualTo(1.0d));
        }

        [Test]
        public void TestRenderPlotsShouldRenderYAxisValue()
        {
            _mockMapFactory.Setup(p => p.CreateAxisMap(_column, 0d, 1d, false))
                .Returns(_mockYAxisMap.Object);

            _mockYAxisMap.Setup(p => p.Map(1.0d)).Returns(1.0d);
            
            _layout.YAxisColumn = _column;

            var results = _renderer.RenderPlots(_rows, _layout);

            Assert.That(results.Single().Y, Is.EqualTo(1.0d));
        }

        [Test]
        public void TestRenderPlotsShouldRenderColorValue()
        {
            _mockMapFactory.Setup(p => p.CreateColorMap(_column, _colorPalette))
                .Returns(_mockColorMap.Object);

            _mockColorMap.Setup(p => p.Map(1.0d)).Returns(_color);

            _layout.ColorColumn = _column;
            _layout.ColorPalette = _colorPalette;

            var results = _renderer.RenderPlots(_rows, _layout);

            Assert.That(results.Single().Color, Is.EqualTo(_color));
        }

        [Test]
        public void TestRenderPlotsShouldRenderSizeValue()
        {
            _mockMapFactory.Setup(p => p.CreateSizeMap(_column, 0d, 1d))
                .Returns(_mockSizeMap.Object);

            _mockSizeMap.Setup(p => p.Map(1.0d)).Returns(1.0d);

            _layout.SizeColumn = _column;
            _layout.LowerSize = 0d;
            _layout.UpperSize = 1d;

            var results = _renderer.RenderPlots(_rows, _layout);

            Assert.That(results.Single().Size, Is.EqualTo(1.0d));
        }

        [Test]
        public void TestRenderPlotsShouldRenderImageValue()
        {
            var image = new BitmapImage();

            _rows[0][0]= image;

            _layout.ShapeColumn = _column;

            var results = _renderer.RenderPlots(_rows, _layout);

            Assert.That(results.Single().Image, Is.EqualTo(image));
        }

        [Test]
        public void TestRenderPlotsShouldRenderLabelValue()
        {
            _mockMapFactory.Setup(p => p.CreateLabelMap(_column))
                .Returns(_mockLabelMap.Object);

            _mockLabelMap.Setup(p => p.Map(1.0d)).Returns("0.1");

            _layout.LabelColumn = _column;
            
            var results = _renderer.RenderPlots(_rows, _layout);

            Assert.That(results.Single().Label, Is.EqualTo("0.1"));
        }

    }
}
