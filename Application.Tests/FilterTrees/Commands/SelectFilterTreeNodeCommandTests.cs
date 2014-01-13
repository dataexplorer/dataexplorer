using DataExplorer.Application.Application;
using DataExplorer.Application.Core.Events;
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
        private FakeFilter _filter;
        private FakeFilter _previousFilter;
        private FakeFilterTreeNode _node;

        [SetUp]
        public void SetUp()
        {
            _filter = new FakeFilter();
            _previousFilter = new FakeFilter();
            _node = new FakeFilterTreeNode(_filter);
            
            _mockRepository = new Mock<IFilterRepository>();
            
            _mockService = new Mock<IApplicationStateService>();
            _mockService.Setup(p => p.GetSelectedFilter()).Returns(_previousFilter);

            _mockEventBus = new Mock<IEventBus>();
            
            _handler = new SelectFilterTreeNodeCommandHandler(
                _mockRepository.Object,
                _mockService.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestHandlShouldRemovePreviousFilterInRepository()
        {
            _handler.Execute(new SelectFilterTreeNodeCommand(_node));
            _mockRepository.Verify(p => p.Remove(_previousFilter), Times.Once());
        }

        [Test]
        public void TestHandleShouldSetSelectedFilterInApplicationState()
        {
            _handler.Execute(new SelectFilterTreeNodeCommand(_node));
            _mockService.Verify(p => p.SetSelectedFilter(_filter), Times.Once());
        }

        [Test]
        public void TestHandleShouldAddFilterToRepository()
        {
            _handler.Execute(new SelectFilterTreeNodeCommand(_node));
            _mockRepository.Verify(p => p.Add(_filter));
        }

        [Test]
        public void TestHandleShouldRaiseFilterChangedEvent()
        {
            _handler.Execute(new SelectFilterTreeNodeCommand(_node));
            _mockEventBus.Verify(p => p.Raise(It.IsAny<FilterChangedEvent>()));
        }
    }
}
