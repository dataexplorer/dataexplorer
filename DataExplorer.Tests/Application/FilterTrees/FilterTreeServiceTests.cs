using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.FilterTrees;
using DataExplorer.Application.FilterTrees.Events;
using DataExplorer.Application.FilterTrees.Queries;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.FilterTrees
{
    [TestFixture]
    public class FilterTreeServiceTests
    {
        private FilterTreeService _service;
        private Mock<IGetRootFilterTreeNodesQuery> _mockGetRootsTasks;
        private Mock<ISelectedFilterTreeNodeChangedEventHandler> _mockHandleTask;

        [SetUp]
        public void SetUp()
        {
            _mockGetRootsTasks = new Mock<IGetRootFilterTreeNodesQuery>();
            _mockHandleTask = new Mock<ISelectedFilterTreeNodeChangedEventHandler>();
            _service = new FilterTreeService(
                _mockGetRootsTasks.Object,
                _mockHandleTask.Object);
        }

        [Test]
        public void TestGetRootsShouldReturnRoots()
        {
            var root = new FakeFilterTreeNode();
            var roots = new List<FilterTreeNode> { root };
            _mockGetRootsTasks.Setup(p => p.GetRoots()).Returns(roots);
            var result = _service.GetRoots();
            Assert.That(result, Is.EqualTo(roots));
        }

        [Test]
        public void TestHandleShouldHandleEvent()
        {
            var @event = new SelectedFilterTreeNodeChangedEvent(null);
            _service.Handle(@event);
            _mockHandleTask.Verify(p => p.Handle(@event));
        }
    }
}
