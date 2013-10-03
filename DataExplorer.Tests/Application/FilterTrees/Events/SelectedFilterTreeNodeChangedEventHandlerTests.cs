using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.FilterTrees;
using DataExplorer.Application.FilterTrees.Tasks;
using DataExplorer.Application.Filters;
using DataExplorer.Domain.Filters;
using DataExplorer.Tests.Application.Filters;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.FilterTrees.Tasks
{
    [TestFixture]
    public class SelectedFilterTreeNodeChangedEventHandlerTests
    {
        private SelectedFilterTreeNodeChangedEventHandler _eventHandler;
        private Mock<IFilterRepository> _mockRepository;
        private Mock<IApplicationStateService> _mockService;
        private FakeFilter _filter;
        private FakeFilter _previousFilter;
        private FakeFilterTreeNode _node;
        private SelectedFilterTreeNodeChangedEvent _event;

        [SetUp]
        public void SetUp()
        {
            _filter = new FakeFilter();
            _previousFilter = new FakeFilter();
            _node = new FakeFilterTreeNode(_filter);
            _event = new SelectedFilterTreeNodeChangedEvent(_node);
            
            _mockRepository = new Mock<IFilterRepository>();
            
            _mockService = new Mock<IApplicationStateService>();
            _mockService.Setup(p => p.SelectedFilter).Returns(_previousFilter);
            
            _eventHandler = new SelectedFilterTreeNodeChangedEventHandler(
                _mockRepository.Object,
                _mockService.Object);
        }

        [Test]
        public void TestHandlShouldRemovePreviousFilterInRepository()
        {
            _eventHandler.Handle(_event);
            _mockRepository.Verify(p => p.Remove(_previousFilter), Times.Once());
        }

        [Test]
        public void TestHandleShouldSetSelectedFilterInApplicationState()
        {
            _eventHandler.Handle(_event);
            _mockService.VerifySet(p => p.SelectedFilter = _filter, Times.Once());
        }

        [Test]
        public void TestHandleShouldAddFilterToRepository()
        {
            _eventHandler.Handle(_event);
            _mockRepository.Verify(p => p.Add(_filter));
        }

        [Test]
        public void TestHandleShouldRaiseFilterChangedEvent()
        {
            var wasRaised = false;
            AppEvents.Register<FilterChangedEvent>(p => { wasRaised = true; });
            _eventHandler.Handle(_event);
            Assert.That(wasRaised, Is.True);
            AppEvents.ClearHandlers();
        }
    }
}
