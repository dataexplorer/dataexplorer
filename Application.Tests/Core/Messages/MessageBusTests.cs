using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Tests.Core.Commands;
using DataExplorer.Application.Tests.Core.Events;
using DataExplorer.Application.Tests.Core.Queries;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Core.Messages
{
    [TestFixture]
    public class MessageBusTests
    {
        private MessageBus _messageBus;
        private Mock<ICommandBus> _mockCommandBus;
        private Mock<IQueryBus> _mockQueryBus;
        private Mock<IEventBus> _mockEventBus;
        private FakeCommand _fakeCommand;
        private FakeQuery _fakeQuery;
        private FakeEvent _fakeEvent;

        [SetUp]
        public void SetUp()
        {
            _fakeCommand = new FakeCommand();
            _fakeQuery = new FakeQuery();
            _fakeEvent = new FakeEvent();
            
            _mockCommandBus = new Mock<ICommandBus>();

            _mockQueryBus = new Mock<IQueryBus>();
            _mockQueryBus.Setup(p => p.Execute(_fakeQuery)).Returns(true);

            _mockEventBus = new Mock<IEventBus>();

            _messageBus = new MessageBus(
                _mockCommandBus.Object,
                _mockQueryBus.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestExecuteShouldExecuteCommand()
        {
            _messageBus.Execute(_fakeCommand);
            _mockCommandBus.Verify(p => p.Execute<ICommand>(_fakeCommand));
        }

        [Test]
        public void TestExecuteShouldExecuteQuery()
        {
            var result = _messageBus.Execute(_fakeQuery);
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestRaiseShouldRaiseEvent()
        {
            _messageBus.Raise(_fakeEvent);
            _mockEventBus.Verify(p => p.Raise<IEvent>(_fakeEvent));
        }
    }
}
