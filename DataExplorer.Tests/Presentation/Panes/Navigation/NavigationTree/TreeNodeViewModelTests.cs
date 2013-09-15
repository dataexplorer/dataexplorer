using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.FilterTrees;
using DataExplorer.Presentation.Panes.Navigation.NavigationTree;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Panes.Navigation.NavigationTree
{
    [TestFixture]
    public class TreeNodeViewModelTests
    {
        private TreeNodeViewModel _viewModel;
        private FakeFilterTreeNode _filterTreeNode;
        private Mock<IFilterTreeService> _mockService;

        [SetUp]
        public void SetUp()
        {
            _filterTreeNode = new FakeFilterTreeNode("Test");
            _mockService = new Mock<IFilterTreeService>();
            _viewModel = new TreeNodeViewModel(
                _filterTreeNode,
                _mockService.Object);
        }

        [Test]
        public void TestGetNameShouldReturnName()
        {
            Assert.That(_viewModel.Name, Is.EqualTo("Test"));
        }
    }
}
