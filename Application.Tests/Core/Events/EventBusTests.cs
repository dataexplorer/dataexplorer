using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Events;
using Ninject;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Core.Events
{
    [TestFixture]
    public class EventBusTests
    {
        private EventBus _bus;
        private IKernel _kernel;
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

            _bus = new EventBus();

            EventBus.Kernel = _kernel;
        }

        [Test]
        public void TestExecuteShouldExecuteEvent()
        {
            _bus.Raise(_event);
            Assert.That(_handler.WasRaised, Is.True);
        }
    }
}
