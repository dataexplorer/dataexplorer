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
        private Mock<IApplicationState> _mockState;
        private Mock<IEventBus> _mockEventBus;
        private FakeFilter _filter;
        private Row _row;
        private List<Row> _rows;

        [SetUp]
        public void SetUp()
        {
            _filter = new FakeFilter();
            _row = new RowBuilder().Build();
            _rows = new List<Row> { _row };

            _mockState = new Mock<IApplicationState>();
            _mockState.SetupGet(p => p.IsStartMenuVisible).Returns(true);
            _mockState.SetupGet(p => p.IsNavigationTreeVisible).Returns(true);
            _mockState.SetupGet(p => p.SelectedFilter).Returns(_filter);
            _mockState.SetupGet(p => p.SelectedRows).Returns(_rows);

            _mockEventBus = new Mock<IEventBus>();

            _service = new ApplicationStateService(
                _mockState.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestGetIsStartMenuVisibleShouldGetState()
        {
            var result = _service.GetIsStartMenuVisible();
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestSetIsStartMenuVisibleShouldSetState()
        {
            _service.SetIsStartMenuVisible(true);
            _mockState.VerifySet(p => p.IsStartMenuVisible = true, Times.Once());
        }

        [Test]
        public void TestSetIsStartMenuVisibleShouldRaiseEvent()
        {
            _service.SetIsStartMenuVisible(true);
            _mockEventBus.Verify(p => p.Raise(It.IsAny<StartMenuVisibilityChangedEvent>()), Times.Once());
        }

        [Test]
        public void TestGetIsNavigationTreeVisibleShouldGetState()
        {
            var result = _service.GetIsNavigationTreeVisible();
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestSetIsNavigationTreeVisibleShouldSetState()
        {
            _service.SetIsNavigationTreeVisible(true);
            _mockState.VerifySet(p => p.IsNavigationTreeVisible = true, Times.Once());
        }

        [Test]
        public void TestSetIsNavigationTreeVisibleShouldRaiseEvent()
        {
            _service.SetIsNavigationTreeVisible(true);
            _mockEventBus.Verify(p => p.Raise(It.IsAny<NavigationTreeVisibilityChangedEvent>()), Times.Once());
        }

        [Test]
        public void TestGetSelectedFilterTreeShouldGetState()
        {
            var result = _service.GetSelectedFilter();
            Assert.That(result, Is.EqualTo(_filter));
        }

        [Test]
        public void TestSetSelectedFilterTreeShouldSetState()
        {
            _service.SetSelectedFilter(_filter);
            _mockState.VerifySet(p => p.SelectedFilter = _filter, Times.Once());
        }

        // TODO: TestSetSelectedFilterTreeShouldRaiseEvent()

        [Test]
        public void TestGetSelectedRowsShouldGetState()
        {
            var result = _service.GetSelectedRows();
            Assert.That(result.Single(), Is.EqualTo(_row));
        }

        [Test]
        public void TestSetSelectedRowsShouldSetState()
        {
            _service.SetSelectedRows(_rows);
            _mockState.VerifySet(p => p.SelectedRows = _rows, Times.Once());
        }

        [Test]
        public void TestHandleCsvFileImportingEventShouldSetIsStartMenuVisibleToFalse()
        {
            _service.Handle(new CsvFileImportingEvent());
            _mockState.VerifySet(p => p.IsStartMenuVisible = false, Times.Once());
        }

        [Test]
        public void TestHandleCsvFileImportingEventShouldRaiseStartMenuVisibilityChangedEvent()
        {
            _service.Handle(new CsvFileImportingEvent());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<StartMenuVisibilityChangedEvent>()));
        }

        [Test]
        public void TestHandleCsvFileImportingEventShouldSetIsNavigationTreeVisibleToFalse()
        {
            _service.Handle(new CsvFileImportingEvent());
            _mockState.VerifySet(p => p.IsNavigationTreeVisible = false, Times.Once());
        }

        [Test]
        public void TestHandleCsvFileImportingEventShouldRaiseNavigationTreeVisibilityChangedEvent()
        {
            _service.Handle(new CsvFileImportingEvent());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<NavigationTreeVisibilityChangedEvent>()));
        }

        [Test]
        public void TestHandleCsvFileImportingEventShouldSetSelectedFilterToNull()
        {
            _service.Handle(new CsvFileImportingEvent());
            _mockState.VerifySet(p => p.SelectedFilter = null, Times.Once());
        }

        
        // TODO: public void TestHandleCsvFileImportingEventShouldRaiseSelectedFilterChangedEvent()

        [Test]
        public void TestHandleCsvFileImportingEventShouldClearSelectedRows()
        {
            _service.Handle(new CsvFileImportingEvent());
            _mockState.VerifySet(p => p.SelectedRows = new List<Row>(), Times.Once());
        }

        [Test]
        public void TestHandleCsvFileImportingEventShouldRaiseSelectedRowsChangedEvent()
        {
            _service.Handle(new CsvFileImportingEvent());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<SelectedRowsChangedEvent>()));
        }

        [Test]
        public void TestHandleCsvFileImportedEventShouldSetIsStartMenuVisibleToFalse()
        {
            _service.Handle(new CsvFileImportedEvent());
            _mockState.VerifySet(p => p.IsStartMenuVisible = false, Times.Once());
        }

        [Test]
        public void TestHandleCsvFileImportedEventShouldRaiseStartMenuVisibilityChangedEvent()
        {
            _service.Handle(new CsvFileImportedEvent());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<StartMenuVisibilityChangedEvent>()));
        }

        [Test]
        public void TestHandleCsvFileImportedEventShouldSetIsNavigationTreeVisibleToFalse()
        {
            _service.Handle(new CsvFileImportedEvent());
            _mockState.VerifySet(p => p.IsNavigationTreeVisible = true, Times.Once());
        }

        [Test]
        public void TestHandleCsvFileImportedEventShouldRaiseNavigationTreeVisibilityChangedEvent()
        {
            _service.Handle(new CsvFileImportedEvent());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<NavigationTreeVisibilityChangedEvent>()));
        }
    }
}
