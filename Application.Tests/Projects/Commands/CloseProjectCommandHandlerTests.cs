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
        private Mock<IDataContext> _mockDataContext;
        private Mock<IEventBus> _mockEventBus;

        [SetUp]
        public void SetUp()
        {
            _mockDataContext = new Mock<IDataContext>();

            _mockEventBus = new Mock<IEventBus>();

            _handler = new CloseProjectCommandHandler(
                _mockDataContext.Object,
                _mockEventBus.Object);
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
