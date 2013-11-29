using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Titles.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.Titles.Renderers;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.Titles.Queries
{
    [TestFixture]
    public class GetXAxisTitleQueryTests
    {
        private GetXAxisTitleQuery _query;
        private Mock<IScatterPlotLayoutService> _mockService;
        private Mock<IXAxisTitleRenderer> _mockRenderer;
        private Size _controlSize;
        private ColumnDto _column;
        private CanvasLabel _item;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size();
            _column = new ColumnDto() { Name = "Test" };
            _item = new CanvasLabel();

            _mockService = new Mock<IScatterPlotLayoutService>();
            _mockService.Setup(p => p.GetXColumn()).Returns(_column);

            _mockRenderer = new Mock<IXAxisTitleRenderer>();
            _mockRenderer.Setup(p => p.Render(_controlSize, _column.Name)).Returns(_item);

            _query = new GetXAxisTitleQuery(
                _mockService.Object,
                _mockRenderer.Object);
        }

        [Test]
        public void TestExecuteShouldReturnXAxisTitle()
        {
            var results = _query.Execute(_controlSize);
            Assert.That(results, Is.EqualTo(_item));
        }

        [Test]
        public void TestExecuteShouldReturnEmptyXAxisTitleIfColumnIsNull()
        {
            _mockService.Setup(p => p.GetXColumn()).Returns((ColumnDto) null);
            _mockRenderer.Setup(p => p.Render(_controlSize, string.Empty)).Returns(_item);
            var result = (CanvasLabel) _query.Execute(_controlSize);
            Assert.That(result, Is.EqualTo(_item));
        }
    }
}
