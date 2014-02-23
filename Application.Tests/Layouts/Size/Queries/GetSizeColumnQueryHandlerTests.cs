using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Layouts.Size.Queries;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Size.Queries
{
    [TestFixture]
    public class GetSizeColumnQueryHandlerTests
    {
        private GetSizeColumnQueryHandler _handler;
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
            _layout = new ScatterPlotLayoutBuilder()
                .WithSizeColumn(_column)
                .Build();
            _scatterPlot = new ScatterPlotBuilder()
                .WithLayout(_layout)
                .Build();

            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>())
                .Returns(_scatterPlot);

            _mockAdapter = new Mock<IColumnAdapter>();
            _mockAdapter.Setup(p => p.Adapt(_column))
                .Returns(_columnDto);

            _handler = new GetSizeColumnQueryHandler(
                _mockRepository.Object,
                _mockAdapter.Object);
        }

        [Test]
        public void TestExecuteShouldReturnColorColumn()
        {
            var result = _handler.Execute(new GetSizeColumnQuery());
            Assert.That(result, Is.EqualTo(_columnDto));
        }
    }
}
