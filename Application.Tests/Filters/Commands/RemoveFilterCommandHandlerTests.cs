using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Filters;
using DataExplorer.Application.Filters.Commands;
using DataExplorer.Application.Filters.Events;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Tests.Filters;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Filters.Commands
{
    [TestFixture]
    public class RemoveFilterCommandHandlerTests
    {
        private RemoveFilterCommandHandler _hander;
        private Mock<IApplicationStateService> _mockStateService;
        private Mock<IFilterRepository> _mockRepository;
        private Mock<IEventBus> _mockEventBus;
        private Filter _filter;

        [SetUp]
        public void SetUp()
        {
            _filter = new FakeFilter();

            _mockStateService = new Mock<IApplicationStateService>();
            _mockRepository = new Mock<IFilterRepository>();
            _mockEventBus = new Mock<IEventBus>();

            _hander = new RemoveFilterCommandHandler(
                _mockStateService.Object,
                _mockRepository.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestExecuteShouldUnsetSelectedFilterIfItMatches()
        {
            _mockStateService.Setup(p => p.GetSelectedFilter()).Returns(_filter);
            _hander.Execute(new RemoveFilterCommand(_filter));
            _mockStateService.Verify(p => p.SetSelectedFilter(null), Times.Once());
        }

        [Test]
        public void TestExecuteShouldNotUnsetSelectedFilterIfItDoesNotMatches()
        {
            _hander.Execute(new RemoveFilterCommand(_filter));
            _mockStateService.Verify(p => p.SetSelectedFilter(_filter), Times.Never());
        }

        [Test]
        public void TestExecuteShouldRemoveFilterFromRepository()
        {
            _hander.Execute(new RemoveFilterCommand(_filter));
            _mockRepository.Verify(p => p.Remove(_filter), Times.Once());
        }

        [Test]
        public void TestExecuteShouldRaiseFilterRemovedEvent()
        {
            _hander.Execute(new RemoveFilterCommand(_filter));
            _mockEventBus.Verify(p => p.Raise(
                It.Is<FilterRemovedEvent>(q => q.Filter == _filter)), 
                Times.Once());
        }
    }
}
