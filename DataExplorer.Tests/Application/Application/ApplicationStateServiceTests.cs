using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application;
using DataExplorer.Application.Application;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers.CsvFile.Events;
using DataExplorer.Tests.Application.FilterTrees;
using DataExplorer.Tests.Application.Filters;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Application
{
    [TestFixture]
    public class ApplicationStateServiceTests
    {
        private ApplicationStateService _service;
        private ApplicationState _state;
        private FakeFilter _filter;
        private bool _wasRaised;

        [SetUp]
        public void SetUp()
        {
            _wasRaised = false;
            _filter = new FakeFilter();
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
            Assert.That(_service.IsStartMenuVisible, Is.True);
            Assert.That(_service.IsNavigationTreeVisible, Is.False);
            Assert.That(_service.SelectedFilter, Is.Null);
        }

        [Test]
        public void TestGetIsStartMenuVisibleShouldGetState()
        {
            _state.IsStartMenuVisible = true;
            var result = _service.IsStartMenuVisible;
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestGetIsNavigationTreeVisibleShouldGetState()
        {
            _state.IsNavigationTreeVisible = true;
            var result = _service.IsNavigationTreeVisible;
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestGetSelectedFilterTreeShouldGetState()
        {
            
            _state.SelectedFilter = _filter;
            var result = _service.SelectedFilter;
            Assert.That(result, Is.EqualTo(_filter));
        }

        [Test]
        public void TestSetSelectedFilterTreeShouldSetState()
        {
            _service.SelectedFilter = _filter;
            Assert.That(_state.SelectedFilter, Is.EqualTo(_filter));
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
