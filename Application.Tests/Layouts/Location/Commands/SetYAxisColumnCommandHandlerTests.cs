using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Layouts.Location.Commands;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Location.Commands
{
    [TestFixture]
    public class SetYAxisColumnCommandHandlerTests
    {
        private SetYAxisColumnCommandHandler _handler;
        private Mock<IColumnRepository> _mockColumnRepository;
        private Mock<IViewRepository> _mockRepository;
        private Mock<IEventBus> _mockEventBus;
        private ScatterPlot _scatterPlot;
        private ScatterPlotLayout _layout;
        private Column _column;
        private ColumnDto _columnDto;

        [SetUp]
        public void SetUp()
        {
            _columnDto = new ColumnDto() { Id = 1 };
            _column = new ColumnBuilder().Build();
            _layout = new ScatterPlotLayoutBuilder().Build();
            _scatterPlot = new ScatterPlotBuilder()
                .WithLayout(_layout)
                .Build();

            _mockColumnRepository = new Mock<IColumnRepository>();
            _mockColumnRepository.Setup(p => p.Get(_columnDto.Id))
                .Returns(_column);

            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>())
                .Returns(_scatterPlot);

            _mockEventBus = new Mock<IEventBus>();

            _handler = new SetYAxisColumnCommandHandler(
                _mockColumnRepository.Object,
                _mockRepository.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestExecuteShouldSetYColumn()
        {
            _handler.Execute(new SetYAxisColumnCommand(_columnDto.Id));
            Assert.That(_layout.YAxisColumn, Is.EqualTo(_column));
        }

        [Test]
        public void TestExecuteShouldRaiseLayoutChangedEvent()
        {
            _handler.Execute(new SetYAxisColumnCommand(_columnDto.Id));
            _mockEventBus.Verify(p => p.Raise(It.IsAny<LayoutChangedEvent>()));
        }
    }
}
