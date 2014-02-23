using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Maps.Queries;
using DataExplorer.Application.Tests.Maps;
using DataExplorer.Application.Views;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories;
using DataExplorer.Application.Views.ScatterPlots.Axes.Queries;
using DataExplorer.Application.Views.ScatterPlots.Queries;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots.Axes.Queries
{
    [TestFixture]
    public class GetYAxisGridLinesQueryHandlerTests
    {
        private GetYAxisGridLinesQueryHandler _handler;
        private Mock<IViewRepository> _mockViewRepository;
        private Mock<IMapFactory> _mockMapFactory;
        private Mock<IGridLineFactory> _mockFactory;
        private ScatterPlot _scatterPlot;
        private ScatterPlotLayout _layout;
        private Column _column;
        private Rect _viewExtent;
        private List<object> _values;
        private AxisMap _axisMap;
        private List<AxisGridLine> _axisLines;
        private AxisGridLine _axisGridLine;

        [SetUp]
        public void SetUp()
        {
            _values = new List<object>();
            _column = new ColumnBuilder()
                .WithType(typeof(object))
                .WithValues(_values)
                .Build();
            _layout = new ScatterPlotLayoutBuilder()
                .WithYAxisColumn(_column)
                .Build();
            _scatterPlot = new ScatterPlotBuilder()
                .WithLayout(_layout)
                .Build();
            _viewExtent = new Rect();
            _axisMap = new FakeAxisMap();
            _values = new List<object>();
            _axisGridLine = new AxisGridLine();
            _axisLines = new List<AxisGridLine> { _axisGridLine };

            _mockViewRepository = new Mock<IViewRepository>();
            _mockViewRepository.Setup(p => p.Get<ScatterPlot>())
                .Returns(_scatterPlot);

            _mockMapFactory = new Mock<IMapFactory>();
            _mockMapFactory.Setup(p => p.CreateAxisMap(_column, 0d, 1d))
                .Returns(_axisMap);

            _mockFactory = new Mock<IGridLineFactory>();
            _mockFactory.Setup(p => p.Create(typeof(object), _axisMap, _values, _viewExtent.Left, _viewExtent.Right))
                .Returns(_axisLines);

            _handler = new GetYAxisGridLinesQueryHandler(
                _mockViewRepository.Object,
                _mockMapFactory.Object,
                _mockFactory.Object);
        }

        [Test]
        public void TestExecuteShouldReturnEmptyListIfColumnDtoIsNull()
        {
            _layout.YAxisColumn = null;
            var results = _handler.Execute(new GetYAxisGridLinesQuery());
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void TestExecuteShouldReturnAxisGridLines()
        {
            var results = _handler.Execute(new GetYAxisGridLinesQuery());
            Assert.That(results.Single(), Is.EqualTo(_axisGridLine));
        }
    }
}
