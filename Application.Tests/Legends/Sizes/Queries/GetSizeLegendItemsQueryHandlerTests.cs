using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Legends.Sizes;
using DataExplorer.Application.Legends.Sizes.Factories;
using DataExplorer.Application.Legends.Sizes.Queries;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.SizeMaps;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.Maps;
using DataExplorer.Domain.Tests.Maps.SizeMaps;
using DataExplorer.Domain.Tests.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Legends.Sizes.Queries
{
    [TestFixture]
    public class GetSizeLegendItemsQueryHandlerTests
    {
        private GetSizeLegendItemsQueryHandler _handler;
        private Mock<IViewRepository> _mockViewRepository;
        private Mock<IMapFactory> _mockMapFactory;
        private Mock<ISizeLegendFactory> _mockItemFactory;
        private ScatterPlot _scatterPlot;
        private ScatterPlotLayout _layout;
        private Column _column;
        private List<string> _values;
        private SizeMap _map;
        private SizeLegendItemDto _itemDto;

        [SetUp]
        public void SetUp()
        {
            _values = new List<string> { "test" };
            _column = new ColumnBuilder()
                .WithId(1)
                .WithDataType(typeof(String))
                .WithValue(_values)
                .Build();
            _layout = new ScatterPlotLayoutBuilder()
                .WithSizeColumn(_column)
                .WithLowerSize(0d)
                .WithUpperSize(1d)
                .Build();
            _scatterPlot = new ScatterPlotBuilder()
                .WithLayout(_layout)
                .Build();
            _map = new FakeSizeMap();
            _itemDto = new SizeLegendItemDto();

            _mockViewRepository = new Mock<IViewRepository>();
            _mockViewRepository.Setup(p => p.Get<ScatterPlot>())
                .Returns(_scatterPlot);

            _mockMapFactory = new Mock<IMapFactory>();
            _mockMapFactory.Setup(p => p.CreateSizeMap(_column, _layout.LowerSize, _layout.UpperSize))
                .Returns(_map);

            _mockItemFactory = new Mock<ISizeLegendFactory>();
            _mockItemFactory.Setup(p =>
                p.Create(_column.DataType, _map, It.IsAny<List<object>>(), _layout.LowerSize, _layout.UpperSize))
                .Returns(new List<SizeLegendItemDto> { _itemDto });

            _handler = new GetSizeLegendItemsQueryHandler(
                _mockViewRepository.Object,
                _mockMapFactory.Object,
                _mockItemFactory.Object);
        }

        [Test]
        public void TestExecuteShouldReturnEmptyListIfNoColumnIsSelected()
        {
            _layout.SizeColumn = null;
            var results = _handler.Execute(new GetSizeLegendItemsQuery());
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void TestExecuteShouldReturnSizeLegendItems()
        {
            var results = _handler.Execute(new GetSizeLegendItemsQuery());
            Assert.That(results.Single(), Is.EqualTo(_itemDto));
        }
    }
}
