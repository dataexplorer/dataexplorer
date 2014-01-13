using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Commands;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots.Layouts.Commands
{
    [TestFixture]
    public class SetYColumnCommandHandlerTests
    {
        private SetYColumnCommandHandler _handler;
        private Mock<IColumnRepository> _mockColumnRepository;
        private Mock<IViewRepository> _mockRepository;
        private ScatterPlot _scatterPlot;
        private ScatterPlotLayout _layout;
        private Column _column;
        private ColumnDto _columnDto;

        [SetUp]
        public void SetUp()
        {
            _columnDto = new ColumnDto() { Id = 1 };
            _column = new ColumnBuilder().Build();
            _layout = new ScatterPlotLayout();
            _scatterPlot = new ScatterPlot(_layout, new Rect(), null);

            _mockColumnRepository = new Mock<IColumnRepository>();
            _mockColumnRepository.Setup(p => p.Get(_columnDto.Id)).Returns(_column);

            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>()).Returns(_scatterPlot);

            _handler = new SetYColumnCommandHandler(
                _mockColumnRepository.Object,
                _mockRepository.Object);
        }

        [Test]
        public void TestSetYColumnShouldSetYColumn()
        {
            _handler.Execute(new SetYColumnCommand(_columnDto.Id));
            Assert.That(_layout.YAxisColumn, Is.EqualTo(_column));
        }
    }
}
