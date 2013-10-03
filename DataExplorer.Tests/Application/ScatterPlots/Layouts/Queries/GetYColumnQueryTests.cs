using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.ScatterPlots.Layouts.Queries;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;
using DataExplorer.Tests.Domain.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.ScatterPlots.Layouts.Queries
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
            _scatterPlot = new ScatterPlot(new Rect(), null, _layout);

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
