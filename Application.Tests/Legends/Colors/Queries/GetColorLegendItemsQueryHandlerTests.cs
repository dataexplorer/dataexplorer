using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Legends.Colors;
using DataExplorer.Application.Legends.Colors.Factories;
using DataExplorer.Application.Legends.Colors.Queries;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.ColorMaps;
using DataExplorer.Domain.Tests.Colors;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.Maps;
using DataExplorer.Domain.Tests.Maps.ColorMaps;
using DataExplorer.Domain.Tests.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Legends.Colors.Queries
{
    [TestFixture]
    public class GetColorLegendItemsQueryHandlerTests
    {
        private GetColorLegendItemsQueryHandler _handler;
        private Mock<IViewRepository> _mockViewRepository;
        private Mock<IMapFactory> _mockMapFactory;
        private Mock<IColorLegendFactory> _mockItemFactory;
        private ScatterPlot _scatterPlot;
        private ScatterPlotLayout _layout;
        private Column _column;
        private List<string> _values;
        private ColorMap _map;
        private ColorPalette _palette;
        private ColorLegendItemDto _itemDto;

        [SetUp]
        public void SetUp()
        {
            _values = new List<string> { "test" };
            _column = new ColumnBuilder()
                .WithId(1)
                .WithDataType(typeof(String))
                .WithValue(_values)
                .Build();
            _palette = new ColorPaletteBuilder().Build();
            _layout = new ScatterPlotLayoutBuilder()
                .WithColorColumn(_column)
                .WithColorPalette(_palette)
                .Build();
            _scatterPlot = new ScatterPlotBuilder()
                .WithLayout(_layout)
                .Build();
            _map = new FakeColorMap();
            _itemDto = new ColorLegendItemDto();

            _mockViewRepository = new Mock<IViewRepository>();
            _mockViewRepository.Setup(p => p.Get<ScatterPlot>())
                .Returns(_scatterPlot);

            _mockMapFactory = new Mock<IMapFactory>();
            _mockMapFactory.Setup(p => p.CreateColorMap(_column, _palette, SortOrder.Ascending))
                .Returns(_map);

            _mockItemFactory = new Mock<IColorLegendFactory>();
            _mockItemFactory.Setup(p =>
                p.Create(_column.DataType, _map, It.IsAny<List<object>>(), _palette))
                .Returns(new List<ColorLegendItemDto> { _itemDto });

            _handler = new GetColorLegendItemsQueryHandler(
                _mockViewRepository.Object,
                _mockMapFactory.Object,
                _mockItemFactory.Object);
        }

        [Test]
        public void TestExecuteShouldReturnEmptyListIfNoColumnIsSelected()
        {
            _layout.ColorColumn = null;
            var results = _handler.Execute(new GetColorLegendItemsQuery());
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void TestExecuteShouldReturnColorLegendItems()
        {
            var results = _handler.Execute(new GetColorLegendItemsQuery());
            Assert.That(results.Single(), Is.EqualTo(_itemDto));
        }
    }
}
