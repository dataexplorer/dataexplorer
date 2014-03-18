using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataExplorer.Application.Views;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories;
using DataExplorer.Application.Views.ScatterPlots.Axes.Queries;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.Maps.AxisMaps;
using DataExplorer.Domain.Tests.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots.Axes.Queries
{
    [TestFixture]
    public class GetXAxisGridLinesQueryHandlerTests
    {
        private GetXAxisGridLinesQueryHandler _handler;
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
                .WithDataType(typeof(object))
                .WithValues(_values)
                .Build();
            _layout = new ScatterPlotLayoutBuilder()
                .WithXAxisColumn(_column)
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

            _handler = new GetXAxisGridLinesQueryHandler(
                _mockViewRepository.Object,
                _mockMapFactory.Object,
                _mockFactory.Object);
        }

        [Test]
        public void TestExecuteShouldReturnEmptyListIfColumnDtoIsNull()
        {
            _layout.XAxisColumn = null;
            var results = _handler.Execute(new GetXAxisGridLinesQuery());
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void TestExecuteShouldReturnAxisGridLines()
        {
            var results = _handler.Execute(new GetXAxisGridLinesQuery());
            Assert.That(results.Single(), Is.EqualTo(_axisGridLine));
        }
    }
}
