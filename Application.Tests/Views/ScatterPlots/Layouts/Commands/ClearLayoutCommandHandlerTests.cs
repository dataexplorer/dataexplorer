using System.Windows;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Views;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Commands;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Events;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots.Layouts.Commands
{
    [TestFixture]
    public class ClearLayoutCommandHandlerTests
    {
        private ClearLayoutCommandHandler _handler;
        private Mock<IViewRepository> _mockRepository;
        private Mock<IEventBus> _mockEventBus;
        private ScatterPlot _scatterPlot;
        private ScatterPlotLayout _layout;

        [SetUp]
        public void SetUp()
        {
            var column = new ColumnBuilder().Build();
            _layout = new ScatterPlotLayout()
            {
                XAxisColumn = column,
                YAxisColumn = column
            };
            _scatterPlot = new ScatterPlot(_layout, new Rect(), null);
            
            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>())
                .Returns(_scatterPlot);

            _mockEventBus = new Mock<IEventBus>();

            _handler = new ClearLayoutCommandHandler(
                _mockRepository.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestExecuteShouldClearXAxis()
        {
            _handler.Execute(new ClearLayoutCommand());
            Assert.That(_layout.XAxisColumn, Is.Null);
        }

        [Test]
        public void TestExecuteShouldClearYAxis()
        {
            _handler.Execute(new ClearLayoutCommand());
            Assert.That(_layout.YAxisColumn, Is.Null);
        }

        [Test]
        public void TestExecuteShouldRaiseLayoutChangedEvent()
        {
            _handler.Execute(new ClearLayoutCommand());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<LayoutChangedEvent>()), Times.Once());
        }
    }
}
