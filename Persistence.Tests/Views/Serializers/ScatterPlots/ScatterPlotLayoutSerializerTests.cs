using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Tests.Colors;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Persistence.Projects;
using DataExplorer.Persistence.Views.Serializers.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Persistence.Tests.Views.Serializers.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotLayoutSerializerTests
    {
        private ScatterPlotLayoutSerializer _serializer;
        private Mock<IColorPaletteFactory> _mockColorPaletteFactory;
        private ScatterPlotLayout _layout;
        private List<Column> _columns; 
        private Column _xAxisColumn;
        private Column _yAxisColumn;
        private Column _colorColumn;
        private ColorPalette _colorPalette;
        private XElement _xLayout;

        [SetUp]
        public void SetUp()
        {
            _xAxisColumn = new ColumnBuilder().WithId(1).Build();
            _yAxisColumn = new ColumnBuilder().WithId(2).Build();
            _colorColumn = new ColumnBuilder().WithId(3).Build();
            _colorPalette = new ColorPaletteBuilder().WithName("Pastel 1").Build();

            _columns = new List<Column> { _xAxisColumn, _yAxisColumn, _colorColumn };

            _layout = new ScatterPlotLayout
            {
                XAxisColumn = _xAxisColumn,
                YAxisColumn = _yAxisColumn,
                ColorColumn = _colorColumn,
                ColorPalette = _colorPalette
            };

            _xLayout = new XElement("layout",
                new XElement("x-axis-column-id", 1),
                new XElement("y-axis-column-id", 2),
                new XElement("color-column-id", 3),
                new XElement("color-palette-name", "Pastel 1"));
           
            _mockColorPaletteFactory = new Mock<IColorPaletteFactory>();
            _mockColorPaletteFactory.Setup(p => p.GetColorPalette("Pastel 1"))
                .Returns(_colorPalette);

            _serializer = new ScatterPlotLayoutSerializer(
                new PropertySerializer(),
                _mockColorPaletteFactory.Object);
        }

        [Test]
        public void TestSerializeShouldSerializeLayout()
        {
            var result = _serializer.Serialize(_layout);
            AssertValue(result, "x-axis-column-id", "1");
            AssertValue(result, "y-axis-column-id", "2");
            AssertValue(result, "color-column-id", "3");
            AssertValue(result, "color-palette-name", "Pastel 1");
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
            Assert.That(result.ColorColumn, Is.EqualTo(_colorColumn));
            Assert.That(result.ColorPalette, Is.EqualTo(_colorPalette));
        }
    }
}
