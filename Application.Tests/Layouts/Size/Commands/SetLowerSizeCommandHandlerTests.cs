using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Layouts.Size.Commands;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Tests.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Size.Commands
{
    [TestFixture]
    public class SetLowerSizeCommandHandlerTests
    {
        private SetLowerSizeCommandHandler _handler;
        private Mock<IViewRepository> _mockRepository;
        private Mock<IEventBus> _mockEventBus;
        private ScatterPlot _scatterPlot;
        private ScatterPlotLayout _layout;

        [SetUp]
        public void SetUp()
        {
            _layout = new ScatterPlotLayoutBuilder().Build();
            _scatterPlot = new ScatterPlotBuilder()
                .WithLayout(_layout)
                .Build();

            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>())
                .Returns(_scatterPlot);

            _mockEventBus = new Mock<IEventBus>();

            _handler = new SetLowerSizeCommandHandler(
                _mockRepository.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestExecuteShouldSetLowerSize()
        {
            _handler.Execute(new SetLowerSizeCommand(0.1d));
            Assert.That(_layout.LowerSize, Is.EqualTo(0.1d));
        }

        [Test]
        public void TestExecuteShouldRaiseLayoutChangedEvent()
        {
            _handler.Execute(new SetLowerSizeCommand(0.1d));
            _mockEventBus.Verify(p => p.Raise(It.IsAny<LayoutChangedEvent>()));
        }
    }
}
