using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.FilterTrees;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Domain.FilterTrees;
using DataExplorer.Presentation.Panes.Navigation.NavigationTree;
using DataExplorer.Tests.Application.FilterTrees;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Panes.Navigation.NavigationTree
{
    [TestFixture]
    public class NavigationTreeViewModelTests
    {
        private NavigationTreeViewModel _viewModel;
        private Mock<IFilterTreeService> _service;
        private List<TreeNodeViewModel> _treeNodeViewModels; 
        private bool _wasTreeNodeViewModelChangedRaised = false;

        [SetUp]
        public void SetUp()
        {
            _service = new Mock<IFilterTreeService>();
            _treeNodeViewModels = new List<TreeNodeViewModel>();
            _viewModel = new NavigationTreeViewModel(_service.Object);
            _viewModel.PropertyChanged += (s, e) => 
                { if (e.PropertyName == "TreeNodeViewModels") _wasTreeNodeViewModelChangedRaised = true; };
        }

        [Test]
        public void TestHandleImportingEventShouldClearRootNodeViewModels()
        {
            var treeNodeViewModel = new TreeNodeViewModel(null, null);
            _treeNodeViewModels.Add(treeNodeViewModel);
            _viewModel.Handle(new CsvFileImportingEvent());
            Assert.That(_viewModel.TreeNodeViewModels.Count(), Is.EqualTo(0));
            Assert.That(_wasTreeNodeViewModelChangedRaised, Is.True);
        }

        [Test]
        public void TestHandleImportEventShouldCreateRootNodeViewModels()
        {
            var fakeFilterTreeNode = new FakeFilterTreeNode();
            var filterTreeNodes = new List<FilterTreeNode> { fakeFilterTreeNode };
            _service.Setup(p => p.GetRoots()).Returns(filterTreeNodes);
            _viewModel.Handle(new CsvFileImportedEvent());
            var results = _viewModel.TreeNodeViewModels;
            Assert.That(results.Count(), Is.EqualTo(1));
            Assert.That(_wasTreeNodeViewModelChangedRaised, Is.True);
        }
    }


}
