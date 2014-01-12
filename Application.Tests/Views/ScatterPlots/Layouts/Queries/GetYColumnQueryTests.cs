using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Queries;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots.Layouts.Queries
{
    [TestFixture]
    public class GetYColumnQueryTests
    {
        private GetYColumnQuery _query;
        private Mock<IViewRepository> _mockRepository;
        private Mock<IColumnAdapter> _mockAdapter;
        private ScatterPlot _scatterPlot;
        private ScatterPlotLayout _layout;
        private Column _column;
        private ColumnDto _columnDto;

        [SetUp]
        public void SetUp()
        {
            _columnDto = new ColumnDto();
            _column = new ColumnBuilder().Build();
            _layout = new ScatterPlotLayout() { YAxisColumn = _column };
            _scatterPlot = new ScatterPlot(_layout, new Rect(), null);

            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>()).Returns(_scatterPlot);

            _mockAdapter = new Mock<IColumnAdapter>();
            _mockAdapter.Setup(p => p.Adapt(_column)).Returns(_columnDto);

            _query = new GetYColumnQuery(
                _mockRepository.Object,
                _mockAdapter.Object);
        }

        [Test]
        public void TestQueryShouldReturnColumnDto()
        {
            var result = _query.Query();
            Assert.That(result, Is.EqualTo(_columnDto));
        }
    }
}
