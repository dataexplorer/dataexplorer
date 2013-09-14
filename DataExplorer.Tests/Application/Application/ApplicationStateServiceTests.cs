using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application;
using DataExplorer.Application.Application;
using DataExplorer.Application.Events;
using DataExplorer.Application.Importers.CsvFile.Events;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Application
{
    [TestFixture]
    public class ApplicationStateServiceTests
    {
        private ApplicationStateService _service;
        private ApplicationState _state;
        private bool _wasRaised;

        [SetUp]
        public void SetUp()
        {
            _wasRaised = false;
            AppEvents.Register<ApplicationStateChangedEvent>(e => { _wasRaised = true; });
            _state = new ApplicationState();
            _service = new ApplicationStateService(_state);
        }

        [TearDown]
        public void TearDown()
        {
            AppEvents.ClearHandlers();
        }

        [Test]
        public void TestConstructorShouldSetDefaultState()
        {
            _service = new ApplicationStateService();
            var state = _service.GetState();
            Assert.That(state.IsStartMenuVisible, Is.True);
            Assert.That(state.IsNavigationTreeVisible, Is.False);
        }

        [Test]
        public void TestGetStateReturnsState()
        {
            var result = _service.GetState();
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void TestHandleCsvFileImportingEventShouldSetApplicationState()
        {
            _service.Handle(new CsvFileImportingEvent());
            Assert.That(_state.IsStartMenuVisible, Is.False);
            Assert.That(_state.IsNavigationTreeVisible, Is.False);
        }

        [Test]
        public void TestHandleCsvFileImportingEventShouldRaiseApplicationStateChangedEvent()
        {
            _service.Handle(new CsvFileImportingEvent());
            Assert.That(_wasRaised, Is.True);
        }

        [Test]
        public void TestHandleCsvFileImportedEventShouldSetApplicationState()
        {
            _service.Handle(new CsvFileImportedEvent());
            Assert.That(_state.IsStartMenuVisible, Is.False);
            Assert.That(_state.IsNavigationTreeVisible, Is.True);
        }

        [Test]
        public void TestHandleCsvFileImportedEventShouldRaiseApplicationStateChangedEvent()
        {
            _service.Handle(new CsvFileImportedEvent());
            Assert.That(_wasRaised, Is.True);
        }
    }
}
