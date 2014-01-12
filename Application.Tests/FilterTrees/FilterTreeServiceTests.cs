using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.FilterTrees;
using DataExplorer.Application.FilterTrees.Commands;
using DataExplorer.Application.FilterTrees.Queries;
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
        private Mock<ISelectFilterTreeNodeCommand> _mockSelectCommand;

        [SetUp]
        public void SetUp()
        {
            _mockGetRootsTasks = new Mock<IGetRootFilterTreeNodesQuery>();
            _mockSelectCommand = new Mock<ISelectFilterTreeNodeCommand>();
            _service = new FilterTreeService(
                _mockGetRootsTasks.Object,
                _mockSelectCommand.Object);
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
            var node = new FakeFilterTreeNode();
            _service.SelectFilterTreeNode(node);
            _mockSelectCommand.Verify(p => p.Execute(node));
        }
    }
}
