using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Events;
using Moq;
using Ninject;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Core.Events
{
    [TestFixture]
    public class EventBusTests
    {
        private EventBus _bus;
        private IKernel _kernel;
        private Mock<IEventLogger> _mockLogger;
        private FakeEventHandler _handler;
        private FakeEvent _event;

        [SetUp]
        public void SetUp()
        {
            _event = new FakeEvent();
            _handler = new FakeEventHandler();
            
            _kernel = new StandardKernel();
            _kernel.Bind<IEventHandler<FakeEvent>>()
                .ToConstant(_handler);

            _mockLogger = new Mock<IEventLogger>();

            _bus = new EventBus(
                _mockLogger.Object);

            EventBus.Kernel = _kernel;
        }

        [Test]
        public void TestRaiseShouldLogRaisedMessage()
        {
            _bus.Raise(_event);
            _mockLogger.Verify(p => p.LogRaised(_event), Times.Once());
        }

        [Test]
        public void TestExecuteShouldExecuteEvent()
        {
            _bus.Raise(_event);
            Assert.That(_handler.WasRaised, Is.True);
        }

        [Test]
        public void TestRaiseShouldLogHandledMessage()
        {
            _bus.Raise(_event);
            _mockLogger.Verify(p => p.LogHandled(_event), Times.Once());
        }

        [Test]
        public void TestRaiseShouldLogExceptions()
        {
            _handler.ThrowException = true;
            _bus.Raise(_event);
            _mockLogger.Verify(p => p.LogException(It.IsAny<Exception>()), Times.Once());
        }
    }
}
