using DataExplorer.Application.Application;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.FilterTrees.Commands;
using DataExplorer.Application.Filters.Events;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Domain.Filters;
using DataExplorer.Tests.Application.Filters;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.FilterTrees.Commands
{
    [TestFixture]
    public class SelectedFilterTreeNodeChangedEventHandlerTests
    {
        private SelectFilterTreeNodeCommand _command;
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
            _mockService.Setup(p => p.SelectedFilter).Returns(_previousFilter);

            _mockEventBus = new Mock<IEventBus>();
            
            _command = new SelectFilterTreeNodeCommand(
                _mockRepository.Object,
                _mockService.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestHandlShouldRemovePreviousFilterInRepository()
        {
            _command.Execute(_node);
            _mockRepository.Verify(p => p.Remove(_previousFilter), Times.Once());
        }

        [Test]
        public void TestHandleShouldSetSelectedFilterInApplicationState()
        {
            _command.Execute(_node);
            _mockService.VerifySet(p => p.SelectedFilter = _filter, Times.Once());
        }

        [Test]
        public void TestHandleShouldAddFilterToRepository()
        {
            _command.Execute(_node);
            _mockRepository.Verify(p => p.Add(_filter));
        }

        [Test]
        public void TestHandleShouldRaiseFilterChangedEvent()
        {
            _command.Execute(_node);
            _mockEventBus.Verify(p => p.Raise(It.IsAny<FilterChangedEvent>()));
        }
    }
}
