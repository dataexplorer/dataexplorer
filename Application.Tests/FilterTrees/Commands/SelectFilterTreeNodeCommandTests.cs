using DataExplorer.Application.Application;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Filters;
using DataExplorer.Application.Filters.Events;
using DataExplorer.Application.FilterTrees.Commands;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Tests.Filters;
using DataExplorer.Domain.Tests.FilterTrees;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.FilterTrees.Commands
{
    [TestFixture]
    public class SelectFilterTreeNodeCommandHandlerTests
    {
        private SelectFilterTreeNodeCommandHandler _handler;
        private Mock<IFilterRepository> _mockRepository;
        private Mock<IApplicationStateService> _mockService;
        private Mock<IEventBus> _mockEventBus;
        private FakeFilter _newFilter;
        private FakeFilter _oldFilter;
        private FakeFilterTreeNode _node;

        [SetUp]
        public void SetUp()
        {
            _newFilter = new FakeFilter();
            _oldFilter = new FakeFilter();
            _node = new FakeFilterTreeNode(_newFilter);
            
            _mockRepository = new Mock<IFilterRepository>();
            
            _mockService = new Mock<IApplicationStateService>();
            _mockService.Setup(p => p.GetSelectedFilter()).Returns(_oldFilter);

            _mockEventBus = new Mock<IEventBus>();
            
            _handler = new SelectFilterTreeNodeCommandHandler(
                _mockRepository.Object,
                _mockService.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestHandleShouldNotRemoveFilterFromRepositoryIfNoPreviousFilterWasSelected()
        {
            _mockService.Setup(p => p.GetSelectedFilter()).Returns((Filter) null);
            _handler.Execute(new SelectFilterTreeNodeCommand(_node));
            _mockRepository.Verify(p => p.Remove(_oldFilter), Times.Never());
        }

        [Test]
        public void TestHandleShouldNotRaiseRemoveFilterEventIfNoPreviousFilterWasSelected()
        {
            _mockService.Setup(p => p.GetSelectedFilter()).Returns((Filter)null);
            _handler.Execute(new SelectFilterTreeNodeCommand(_node));
            _mockEventBus.Verify(p => p.Raise(It.Is<FilterRemovedEvent>(q => q.Filter == _oldFilter)), Times.Never());
        }

        [Test]
        public void TestHandlShouldRemovePreviousFilterFromRepository()
        {
            _handler.Execute(new SelectFilterTreeNodeCommand(_node));
            _mockRepository.Verify(p => p.Remove(_oldFilter), Times.Once());
        }

        [Test]
        public void TestHandleShouldRaiseFilterRemovedEvent()
        {
            _handler.Execute(new SelectFilterTreeNodeCommand(_node));
            _mockEventBus.Verify(p => p.Raise(It.Is<FilterRemovedEvent>(q => q.Filter == _oldFilter)), Times.Once());
        }

        [Test]
        public void TestHandleShouldSetSelectedFilterInApplicationState()
        {
            _handler.Execute(new SelectFilterTreeNodeCommand(_node));
            _mockService.Verify(p => p.SetSelectedFilter(_newFilter), Times.Once());
        }

        [Test]
        public void TestHandleShouldAddFilterToRepository()
        {
            _handler.Execute(new SelectFilterTreeNodeCommand(_node));
            _mockRepository.Verify(p => p.Add(_newFilter), Times.Once());
        }

        [Test]
        public void TestHandleShouldRaiseFilterAddedEvent()
        {
            _handler.Execute(new SelectFilterTreeNodeCommand(_node));
            _mockEventBus.Verify(p => p.Raise(It.Is<FilterAddedEvent>(q => q.Filter == _newFilter)), Times.Once());
        }
    }
}
