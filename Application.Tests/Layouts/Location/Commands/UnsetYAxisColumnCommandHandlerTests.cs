using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class UnsetYAxisColumnCommandHandlerTests
    {
        private UnsetYAxisColumnCommandHandler _handler;
        private Mock<IViewRepository> _mockViewRepository;
        private Mock<IEventBus> _mockEventBus;
        private ScatterPlot _view;
        private ScatterPlotLayout _layout;
        private Column _column;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();

            _layout = new ScatterPlotLayoutBuilder()
                .WithYAxisColumn(_column)
                .Build();
            _view = new ScatterPlotBuilder()
                .WithLayout(_layout)
                .Build();

            _mockViewRepository = new Mock<IViewRepository>();
            _mockViewRepository.Setup(p => p.Get<ScatterPlot>())
                .Returns(_view);

            _mockEventBus = new Mock<IEventBus>();

            _handler = new UnsetYAxisColumnCommandHandler(
                _mockViewRepository.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestExecuteShouldUnsetColumn()
        {
            _handler.Execute(new UnsetYAxisColumnCommand());
            Assert.That(_layout.YAxisColumn, Is.Null);
        }

        [Test]
        public void TestExecuteShouldRaiseLayoutChangedEvent()
        {
            _handler.Execute(new UnsetYAxisColumnCommand());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<LayoutChangedEvent>()));
        }
    }
}
