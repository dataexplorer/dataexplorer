using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Grid;
using DataExplorer.Presentation.Views.ScatterPlots.Grid.Labels.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.Grid.Lines.Queries;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.Grid
{
    [TestFixture]
    public class GridQueriesTests
    {
        private GridQueries _queries;
        private Mock<IGetXAxisGridLabelsQuery> _mockXLabelsQuery;
        private Mock<IGetYAxisGridLabelsQuery> _mockYLabelsQuery;
        private Mock<IGetXAxisGridLinesQuery> _mockXLinesQuery;
        private Mock<IGetYAxisGridLinesQuery> _mockYLinesQuery;
        private Size _controlSize;
        private CanvasLabel _label;
        private List<CanvasLabel> _labels;
        private CanvasLine _line;
        private List<CanvasLine> _lines;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size();
            _label = new CanvasLabel();
            _labels = new List<CanvasLabel> { _label };
            _line = new CanvasLine();
            _lines = new List<CanvasLine> { _line };

            _mockXLabelsQuery = new Mock<IGetXAxisGridLabelsQuery>();
            _mockXLabelsQuery.Setup(p => p.Execute(_controlSize)).Returns(_labels);

            _mockYLabelsQuery = new Mock<IGetYAxisGridLabelsQuery>();
            _mockYLabelsQuery.Setup(p => p.Execute(_controlSize)).Returns(_labels);

            _mockXLinesQuery = new Mock<IGetXAxisGridLinesQuery>();
            _mockXLinesQuery.Setup(p => p.Execute(_controlSize)).Returns(_lines);

            _mockYLinesQuery = new Mock<IGetYAxisGridLinesQuery>();
            _mockYLinesQuery.Setup(p => p.Execute(_controlSize)).Returns(_lines);

            _queries = new GridQueries(
                _mockXLabelsQuery.Object,
                _mockYLabelsQuery.Object,
                _mockXLinesQuery.Object,
                _mockYLinesQuery.Object);    
        }

        [Test]
        public void TestGetXAxisLabelsShouldReturnLabels()
        {
            var results = _queries.GetXAxisGridLabels(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_label));
        }

        [Test]
        public void TestGetYAxisLabelsShouldReturnLabels()
        {
            var results = _queries.GetYAxisGridLabels(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_label));
        }

        [Test]
        public void TestGetXAxisGridLinesShouldReturnGridLines()
        {
            var results = _queries.GetXAxisGridLines(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_line));
        }

        [Test]
        public void TestGetYAxisGridLinesShouldReturnGridLines()
        {
            var results = _queries.GetYAxisGridLines(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_line));
        }
    }
}
