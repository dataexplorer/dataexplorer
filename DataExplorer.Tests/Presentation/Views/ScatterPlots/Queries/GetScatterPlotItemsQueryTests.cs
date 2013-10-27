using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.AxisTitles.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.Plots;
using DataExplorer.Presentation.Views.ScatterPlots.Plots.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.Queries;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.Queries
{
    [TestFixture]
    public class GetScatterPlotItemsQueryTests
    {
        private GetScatterPlotItemsQuery _query;
        private Mock<IGetScatterPlotXAxisGridLinesQuery> _mockGetXGridLinesQuery;
        private Mock<IGetScatterPlotPlotsQuery> _mockGetPlotsQuery;
        private Mock<IGetScatterPlotXAxisTitleQuery> _mockGetXAxisTitleQuery;
        private Mock<IGetScatterPlotYAxisTitleQuery> _mockGetYAxisTitleQuery;
        private Size _controlSize;
        private List<CanvasLine> _xAxisGridLines;
        private CanvasLine _xAxisGridLine;
        private List<ICanvasItem> _plotItems;
        private ICanvasItem _plotItem;
        private ICanvasItem _xAxisTitleItem;
        private ICanvasItem _yAxisTitleItem;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size();
            _xAxisGridLine = new CanvasLine();
            _xAxisGridLines = new List<CanvasLine> { _xAxisGridLine };
            _plotItem = new CanvasCircle();
            _plotItems = new List<ICanvasItem> { _plotItem };
            _xAxisTitleItem = new CanvasLabel();
            _yAxisTitleItem = new CanvasLabel();

            _mockGetXGridLinesQuery = new Mock<IGetScatterPlotXAxisGridLinesQuery>();

            _mockGetPlotsQuery = new Mock<IGetScatterPlotPlotsQuery>();
            
            _mockGetXAxisTitleQuery = new Mock<IGetScatterPlotXAxisTitleQuery>();
            
            _mockGetYAxisTitleQuery = new Mock<IGetScatterPlotYAxisTitleQuery>();

            _query = new GetScatterPlotItemsQuery(
                _mockGetXGridLinesQuery.Object,
                _mockGetPlotsQuery.Object,
                _mockGetXAxisTitleQuery.Object,
                _mockGetYAxisTitleQuery.Object);
        }

        [Test]
        public void TestExecuteShouldReturnXAxisGridLines()
        {
            _mockGetXGridLinesQuery.Setup(p => p.Execute(_controlSize)).Returns(_xAxisGridLines);
            var results = _query.Execute(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_xAxisGridLine));
        }

        [Test]
        public void TestGetPlotItemsShouldReturnPlotItems()
        {
            _mockGetPlotsQuery.Setup(p => p.Execute(_controlSize)).Returns(_plotItems);
            var results = _query.Execute(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_plotItem));
        }

        [Test]
        public void TestGetPlotItemsShouldXAxisTitleItem()
        {
            _mockGetXAxisTitleQuery.Setup(p => p.Execute(_controlSize)).Returns(_xAxisTitleItem);
            var results = _query.Execute(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_xAxisTitleItem));
        }

        [Test]
        public void TestGetPlotItemsShouldYAxisTitleItem()
        {
            _mockGetYAxisTitleQuery.Setup(p => p.Execute(_controlSize)).Returns(_yAxisTitleItem);
            var results = _query.Execute(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_yAxisTitleItem));
        }
    }
}
