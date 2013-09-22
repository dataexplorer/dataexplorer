using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Events;
using DataExplorer.Application.FilterTrees;
using DataExplorer.Domain.Columns;
using DataExplorer.Presentation.Panes.Navigation.NavigationTree;
using DataExplorer.Tests.Application.FilterTrees;
using DataExplorer.Tests.Domain.Columns;
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
            var wasRaised = false;
            AppEvents.Register<SelectedFilterTreeNodeChangedEvent>(p => { wasRaised = true; });
            _viewModel.IsSelected = true;
            Assert.That(wasRaised, Is.True);
        }
    }
}
