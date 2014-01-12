using DataExplorer.Application.FilterTrees;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.FilterTrees;
using DataExplorer.Presentation.Panes.Navigation.NavigationTree;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Navigation.NavigationTree
{
    [TestFixture]
    public class TreeNodeViewModelTests
    {
        private TreeNodeViewModel _viewModel;
        private FakeFilterTreeNode _filterTreeNode;
        private Mock<IFilterTreeService> _mockService;
        private Column _column;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();
            _filterTreeNode = new FakeFilterTreeNode("Test", _column);
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

        [Test]
        public void TestSetIsSelectedShouldSetIsSelected()
        {
            _viewModel.IsSelected = true;
            Assert.That(_viewModel.IsSelected, Is.True);
        }

        [Test]
        public void TestSetIsSelectedShouldRaisePropertyChangedEvent()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) => { wasRaised = (e.PropertyName == "IsSelected") ; };
            _viewModel.IsSelected = true;
            Assert.That(wasRaised, Is.True);
        }

        [Test]
        public void TestSetIsSelectedToTrueShouldRaiseEvent()
        {
            _viewModel.IsSelected = true;
            _mockService.Verify(p => p.SelectFilterTreeNode(_filterTreeNode), Times.Once());
        }
    }
}
