using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Grid;
using DataExplorer.Presentation.Views.ScatterPlots.Plots.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.Titles;
using Moq;
using NUnit.Framework;
using IGetPlotsQuery = DataExplorer.Presentation.Views.ScatterPlots.Plots.Queries.IGetPlotsQuery;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.Queries
{
    [TestFixture]
    public class GetAllItemsQueryTests
    {
        private GetAllItemsQuery _query;
        private Mock<IGridQueries> _mockAxisGridQueries;
        private Mock<IGetPlotsQuery> _mockGetPlotsQuery;
        private Mock<ITitleQueries> _mockAxisTitleQueries;
        private Size _controlSize;
        private List<CanvasLine> _gridLines;
        private CanvasLine _gridLine;
        private List<CanvasItem> _plotItems;
        private CanvasItem _plotItem;
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
            _plotItems = new List<CanvasItem> { _plotItem };
            _gridLabel = new CanvasLabel();
            _gridLabels = new List<CanvasLabel> { _gridLabel };
            _titleLabel = new CanvasLabel();
            
            _mockAxisGridQueries = new Mock<IGridQueries>();

            _mockGetPlotsQuery = new Mock<IGetPlotsQuery>();
            
            _mockAxisTitleQueries = new Mock<ITitleQueries>();
            
            _query = new GetAllItemsQuery(
                _mockAxisGridQueries.Object,
                _mockGetPlotsQuery.Object,
                _mockAxisTitleQueries.Object);
        }

        [Test]
        public void TestExecuteShouldReturnXAxisGridLines()
        {
            _mockAxisGridQueries.Setup(p => p.GetXAxisGridLines(_controlSize)).Returns(_gridLines);
            var results = _query.Execute(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_gridLine));
        }

        [Test]
        public void TestExecuteShouldReturnYAxisGridLines()
        {
            _mockAxisGridQueries.Setup(p => p.GetYAxisGridLines(_controlSize)).Returns(_gridLines);
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
            _mockAxisGridQueries.Setup(p => p.GetXAxisGridLabels(_controlSize)).Returns(_gridLabels);
            var results = _query.Execute(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_gridLabel));
        }

        [Test]
        public void TestExecuteShouldReturnYAxisGridLabels()
        {
            _mockAxisGridQueries.Setup(p => p.GetYAxisGridLabels(_controlSize)).Returns(_gridLabels);
            var results = _query.Execute(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_gridLabel));
        }

        [Test]
        public void TestGetPlotItemsShouldXAxisTitleItem()
        {
            _mockAxisTitleQueries.Setup(p => p.GetXAxisTitle(_controlSize)).Returns(_titleLabel);
            var results = _query.Execute(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_titleLabel));
        }

        [Test]
        public void TestGetPlotItemsShouldYAxisTitleItem()
        {
            _mockAxisTitleQueries.Setup(p => p.GetYAxisTitle(_controlSize)).Returns(_titleLabel);
            var results = _query.Execute(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_titleLabel));
        }
    }
}
