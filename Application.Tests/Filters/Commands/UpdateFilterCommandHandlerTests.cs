using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Filters.Commands;
using DataExplorer.Application.Filters.Events;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Tests.Filters;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Filters.Commands
{
    [TestFixture]
    public class UpdateFilterCommandHandlerTests
    {
        private UpdateFilterCommandHandler _handler;
        private Mock<IEventBus> _mockEventBus;
        private Filter _filter;

        [SetUp]
        public void SetUp()
        {
            _filter = new FakeFilter();

            _mockEventBus = new Mock<IEventBus>();

            _handler = new UpdateFilterCommandHandler(
                _mockEventBus.Object);
        }

        [Test]
        public void TestExecuteShouldRaiseFilterChangedEvent()
        {
            _handler.Execute(new UpdateFilterCommand(_filter));
            _mockEventBus.Verify(p => p.Raise(
                It.Is<FilterChangedEvent>(q => q.Filter == _filter)), 
                Times.Once());
        }
    }
}
