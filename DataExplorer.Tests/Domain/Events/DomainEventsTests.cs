using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Common.Injection;
using DataExplorer.Domain.Events;
using NUnit.Framework;
using Ninject;

namespace DataExplorer.Tests.Domain.Events
{
    [TestFixture]
    public class DomainEventsTests
    {
        private bool _wasHandled;
        private FakeDomainEvent _event;

        [SetUp]
        public void SetUp()
        {
            _wasHandled = false;
            _event = new FakeDomainEvent();
        }

        [TearDown]
        public void TearDown()
        {
            DomainEvents.ClearHandlers();
        }
        
        [Test]
        public void TestRegisterShouldRegisterEvent()
        {

            DomainEvents.Register<FakeDomainEvent>(p => { _wasHandled = true; });
            DomainEvents.Raise(_event);
            Assert.That(_wasHandled, Is.True);
        }

        [Test]
        public void TestRaiseShouldRaiseARegisteredEvent()
        {
            DomainEvents.Register<FakeDomainEvent>(p => { _wasHandled = true; });
            DomainEvents.Raise(_event);
            Assert.That(_wasHandled, Is.True);
        }

        [Test]
        public void TestRaiseShouldRaiseAResolvedEvent()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IHandler<FakeDomainEvent>>().To<FakeDomainEventHandler>().InSingletonScope();
            var handler = (FakeDomainEventHandler) kernel.Get<IHandler<FakeDomainEvent>>();
            DomainEvents.Kernel = kernel;
            DomainEvents.Raise(_event);
            Assert.That(handler.WasHandled, Is.True);
            DomainEvents.Kernel = null;
        }

        [Test]
        public void TestClearHandlersShouldClearRegisteredHandlers()
        {
            DomainEvents.Register<FakeDomainEvent>(p => { _wasHandled = true; });
            DomainEvents.ClearHandlers();
            DomainEvents.Raise(_event);
            Assert.That(_wasHandled, Is.False);
        }
    }
}
