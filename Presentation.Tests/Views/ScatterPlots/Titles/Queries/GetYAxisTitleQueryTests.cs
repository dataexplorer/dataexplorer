using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Queries;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Titles.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.Titles.Renderers;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots.Titles.Queries
{
    [TestFixture]
    public class GetYAxisTitleQueryTests
    {
        private GetYAxisTitleQuery _query;
        private Mock<IQueryBus> _mockQueryBus;
        private Mock<IYAxisTitleRenderer> _mockRenderer;
        private Size _controlSize;
        private ColumnDto _column;
        private CanvasLabel _item;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size();
            _column = new ColumnDto() { Name = "Test" };
            _item = new CanvasLabel();

            _mockQueryBus = new Mock<IQueryBus>();
            _mockQueryBus.Setup(p => p.Execute(It.IsAny<GetYColumnQuery>()))
                .Returns(_column);

            _mockRenderer = new Mock<IYAxisTitleRenderer>();
            _mockRenderer.Setup(p => p.Render(_controlSize, _column.Name))
                .Returns(_item);

            _query = new GetYAxisTitleQuery(
                _mockQueryBus.Object,
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
            _mockQueryBus.Setup(p => p.Execute(It.IsAny<GetYColumnQuery>()))
                .Returns((ColumnDto)null);
            _mockRenderer.Setup(p => p.Render(_controlSize, string.Empty))
                .Returns(_item);
            var result = (CanvasLabel)_query.Execute(_controlSize);
            Assert.That(result, Is.EqualTo(_item));
        }
    }
}
