using DataExplorer.Domain.Events;
using Ninject;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Events
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
            kernel.Bind<IDomainHandler<FakeDomainEvent>>().To<FakeDomainEventDomainHandler>().InSingletonScope();
            var handler = (FakeDomainEventDomainHandler) kernel.Get<IDomainHandler<FakeDomainEvent>>();
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
