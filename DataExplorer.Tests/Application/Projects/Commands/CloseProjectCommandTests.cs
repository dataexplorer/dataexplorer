using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Projects.Commands;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Projects;
using DataExplorer.Persistence;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Projects.Commands
{
    [TestFixture]
    public class CloseProjectCommandTests
    {
        private CloseProjectCommand _command;
        private Mock<IDataContext> _mockDataContext;
        private Mock<IEventBus> _mockEventBus;

        [SetUp]
        public void SetUp()
        {
            _mockDataContext = new Mock<IDataContext>();

            _mockEventBus = new Mock<IEventBus>();

            _command = new CloseProjectCommand(
                _mockDataContext.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestExecuteShouldClearDataContext()
        {
            _command.Execute();
            _mockDataContext.Verify(p => p.Clear(), Times.Once());
        }

        [Test]
        public void TestExecuteShouldRaiseProjectClosedCommand()
        {
            _command.Execute();
            _mockEventBus.Verify(p => p.Raise(It.IsAny<ProjectClosedEvent>()), Times.Once());
        }
    }
}
