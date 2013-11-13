using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Labels.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Lines.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.AxisTitles.Queries;
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
        private Mock<IGetScatterPlotYAxisGridLinesQuery> _mockGetYGridLinesQuery;
        private Mock<IGetScatterPlotPlotsQuery> _mockGetPlotsQuery;
        private Mock<IGetScatterPlotXAxisGridLabelsQuery> _mockGetXGridLabelsQuery;
        private Mock<IGetScatterPlotYAxisGridLabelsQuery> _mockGetYGridLabelsQuery;
        private Mock<IGetScatterPlotXAxisTitleQuery> _mockGetXAxisTitleQuery;
        private Mock<IGetScatterPlotYAxisTitleQuery> _mockGetYAxisTitleQuery;
        private Size _controlSize;
        private List<CanvasLine> _gridLines;
        private CanvasLine _gridLine;
        private List<ICanvasItem> _plotItems;
        private ICanvasItem _plotItem;
        private IEnumerable<CanvasLabel> _gridLabels;
        private CanvasLabel _gridLabel;
        private CanvasLabel _titleLabel;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size();
            _gridLine = new CanvasLine();
            _gridLines = new List<CanvasLine> { _gridLine };
            _plotItem = new CanvasCircle();
            _plotItems = new List<ICanvasItem> { _plotItem };
            _gridLabel = new CanvasLabel();
            _gridLabels = new List<CanvasLabel> { _gridLabel };
            _titleLabel = new CanvasLabel();
            
            _mockGetXGridLinesQuery = new Mock<IGetScatterPlotXAxisGridLinesQuery>();

            _mockGetYGridLinesQuery = new Mock<IGetScatterPlotYAxisGridLinesQuery>();

            _mockGetPlotsQuery = new Mock<IGetScatterPlotPlotsQuery>();
            
            _mockGetXGridLabelsQuery = new Mock<IGetScatterPlotXAxisGridLabelsQuery>();

            _mockGetYGridLabelsQuery = new Mock<IGetScatterPlotYAxisGridLabelsQuery>();

            _mockGetXAxisTitleQuery = new Mock<IGetScatterPlotXAxisTitleQuery>();
            
            _mockGetYAxisTitleQuery = new Mock<IGetScatterPlotYAxisTitleQuery>();

            _query = new GetScatterPlotItemsQuery(
                _mockGetXGridLinesQuery.Object,
                _mockGetYGridLinesQuery.Object,
                _mockGetPlotsQuery.Object,
                _mockGetXGridLabelsQuery.Object,
                _mockGetYGridLabelsQuery.Object,
                _mockGetXAxisTitleQuery.Object,
                _mockGetYAxisTitleQuery.Object);
        }

        [Test]
        public void TestExecuteShouldReturnXAxisGridLines()
        {
            _mockGetXGridLinesQuery.Setup(p => p.Execute(_controlSize)).Returns(_gridLines);
            var results = _query.Execute(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_gridLine));
        }

        [Test]
        public void TestExecuteShouldReturnYAxisGridLines()
        {
            _mockGetYGridLinesQuery.Setup(p => p.Execute(_controlSize)).Returns(_gridLines);
            var results = _query.Execute(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_gridLine));
        }

        [Test]
        public void TestGetPlotItemsShouldReturnPlotItems()
        {
            _mockGetPlotsQuery.Setup(p => p.Execute(_controlSize)).Returns(_plotItems);
            var results = _query.Execute(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_plotItem));
        }

        [Test]
        public void TestExecuteShouldReturnXAxisGridLabels()
        {
            _mockGetXGridLabelsQuery.Setup(p => p.Execute(_controlSize)).Returns(_gridLabels);
            var results = _query.Execute(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_gridLabel));
        }

        [Test]
        public void TestExecuteShouldReturnYAxisGridLabels()
        {
            _mockGetYGridLabelsQuery.Setup(p => p.Execute(_controlSize)).Returns(_gridLabels);
            var results = _query.Execute(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_gridLabel));
        }

        [Test]
        public void TestGetPlotItemsShouldXAxisTitleItem()
        {
            _mockGetXAxisTitleQuery.Setup(p => p.Execute(_controlSize)).Returns(_titleLabel);
            var results = _query.Execute(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_titleLabel));
        }

        [Test]
        public void TestGetPlotItemsShouldYAxisTitleItem()
        {
            _mockGetYAxisTitleQuery.Setup(p => p.Execute(_controlSize)).Returns(_titleLabel);
            var results = _query.Execute(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_titleLabel));
        }
    }
}
