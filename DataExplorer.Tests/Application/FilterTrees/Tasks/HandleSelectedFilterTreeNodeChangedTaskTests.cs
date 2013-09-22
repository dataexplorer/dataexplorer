using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Events;
using DataExplorer.Application.FilterTrees;
using DataExplorer.Application.FilterTrees.Tasks;
using DataExplorer.Application.Filters;
using DataExplorer.Domain.Filters;
using DataExplorer.Tests.Application.Filters;
using DataExplorer.Tests.Presentation.Panes.Navigation.NavigationTree;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.FilterTrees.Tasks
{
    [TestFixture]
    public class HandleSelectedFilterTreeNodeChangedTaskTests
    {
        private HandleSelectedFilterTreeNodeChangedTask _task;
        private Mock<IFilterRepository> _mockRepository;
        private FakeFilter _filter;
        private FakeFilterTreeNode _node;
        private SelectedFilterTreeNodeChangedEvent _event;

        [SetUp]
        public void SetUp()
        {
            _filter = new FakeFilter();
            _node = new FakeFilterTreeNode(_filter);
            _event = new SelectedFilterTreeNodeChangedEvent(_node);
            _mockRepository = new Mock<IFilterRepository>();
            _task = new HandleSelectedFilterTreeNodeChangedTask(
                _mockRepository.Object);
        }

        [Test]
        public void TestHandleShouldAddFilterToRepository()
        {
            _task.Handle(_event);
            _mockRepository.Verify(p => p.Add(_filter));
        }

        [Test]
        public void TestHandleShouldRaiseFilterChangedEvent()
        {
            var wasRaised = false;
            AppEvents.Register<FilterChangedEvent>(p => { wasRaised = true; });
            _task.Handle(_event);
            Assert.That(wasRaised, Is.True);
            AppEvents.ClearHandlers();
        }
    }
}
