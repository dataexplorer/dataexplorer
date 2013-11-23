using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application;
using DataExplorer.Application.Application;
using DataExplorer.Application.Application.Events;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Domain.Rows;
using DataExplorer.Tests.Application.FilterTrees;
using DataExplorer.Tests.Application.Filters;
using DataExplorer.Tests.Domain.Rows;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Application
{
    [TestFixture]
    public class ApplicationStateServiceTests
    {
        private ApplicationStateService _service;
        private ApplicationState _state;
        private Mock<IEventBus> _mockEventBus;
        private FakeFilter _filter;

        [SetUp]
        public void SetUp()
        {
            _filter = new FakeFilter();
            _state = new ApplicationState();
            _mockEventBus = new Mock<IEventBus>();
            _service = new ApplicationStateService(
                _state,
                _mockEventBus.Object);
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
        public void TestGetSetSelectedRowsShouldGetSetSelectedRows()
        {
            var row = new RowBuilder().Build();
            var rows = new List<Row> { row };
            _service.SelectedRows = rows;
            var result = _service.SelectedRows;
            Assert.That(result.Single(), Is.EqualTo(row));
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
            _mockEventBus.Verify(p => p.Raise(It.IsAny<ApplicationStateChangedEvent>()));
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
            _mockEventBus.Verify(p => p.Raise(It.IsAny<ApplicationStateChangedEvent>()));
        }
    }
}
