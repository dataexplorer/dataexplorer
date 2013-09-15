using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.FilterTrees;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees;
using DataExplorer.Tests.Domain.Columns;
using DataExplorer.Tests.Presentation.Panes.Navigation.NavigationTree;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.FilterTrees
{
    [TestFixture]
    public class FilterTreeServiceTests
    {
        private FilterTreeService _service;
        private Mock<IColumnRepository> _mockRepository;
        private Mock<IFilterTreeNodeFactory> _mockFactory;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new Mock<IColumnRepository>();
            _mockFactory = new Mock<IFilterTreeNodeFactory>();
            _service = new FilterTreeService(
                _mockRepository.Object,
                _mockFactory.Object);
        }

        [Test]
        public void TestGetRootFilterTreeNodesShouldReturnNodes()
        {
            var column = new ColumnBuilder().Build();
            var columns = new List<Column> { column };
            var node = new FakeFilterTreeNode();
            _mockRepository.Setup(p => p.GetAll()).Returns(columns);
            _mockFactory.Setup(p => p.CreateRoot(column)).Returns(node);
            var result = _service.GetRoots();
            Assert.That(result, Contains.Item(node));
        }

        [Test]
        public void TestGetChildrenShouldReturnBooleanChildren()
        {
            var column = new ColumnBuilder().Build();
            var node = new FakeFilterTreeNode("Test", column);
            var children = new List<FilterTreeNode>();
            _mockFactory.Setup(p => p.CreateChildren(node)).Returns(children);
            var result = _service.GetChildren(node);
            Assert.That(result, Is.EqualTo(children));
        }
    }
}
