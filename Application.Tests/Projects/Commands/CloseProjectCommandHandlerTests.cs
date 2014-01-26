using DataExplorer.Application.Application;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Projects.Commands;
using DataExplorer.Application.Projects.Events;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Projects.Commands
{
    [TestFixture]
    public class CloseProjectCommandHandlerTests
    {
        private CloseProjectCommandHandler _handler;
        private Mock<IEventBus> _mockEventBus;
        private Mock<IApplicationStateService> _mockStateService;
        private Mock<IDataContext> _mockDataContext;

        [SetUp]
        public void SetUp()
        {
            _mockEventBus = new Mock<IEventBus>();
            _mockStateService = new Mock<IApplicationStateService>();
            _mockDataContext = new Mock<IDataContext>();

            _handler = new CloseProjectCommandHandler(
                _mockEventBus.Object,
                _mockStateService.Object,
                _mockDataContext.Object);
        }

        [Test]
        public void TestExecuteShouldRaiseProjectClosingCommand()
        {
            _handler.Execute(new CloseProjectCommand());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<ProjectClosingEvent>()), Times.Once());
        }

        [Test]
        public void TestExecuteShouldClearSelectedFilter()
        {
            _handler.Execute(new CloseProjectCommand());
            _mockStateService.Verify(p => p.ClearSelectedFilter(), Times.Once());
        }

        [Test]
        public void TestExecuteShouldClearSelectedRows()
        {
            _handler.Execute(new CloseProjectCommand());
            _mockStateService.Verify(p => p.ClearSelectedRows(), Times.Once());
        }

        [Test]
        public void TestExecuteShouldClearDataContext()
        {
            _handler.Execute(new CloseProjectCommand());
            _mockDataContext.Verify(p => p.Clear(), Times.Once());
        }

        [Test]
        public void TestExecuteShouldRaiseProjectClosedCommand()
        {
            _handler.Execute(new CloseProjectCommand());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<ProjectClosedEvent>()), Times.Once());
        }
    }
}
