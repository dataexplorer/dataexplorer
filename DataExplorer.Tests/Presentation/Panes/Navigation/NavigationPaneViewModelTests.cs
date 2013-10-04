using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Application.Events;
using DataExplorer.Presentation.Panes.Navigation;
using DataExplorer.Presentation.Panes.Navigation.NavigationTree;
using DataExplorer.Presentation.Panes.Navigation.StartMenu;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Panes.Navigation
{
    [TestFixture]
    public class NavigationPaneViewModelTests
    {
        private NavigationPaneViewModel _viewModel;
        private Mock<IStartMenuViewModel> _mockStartMenuViewModel;
        private Mock<INavigationTreeViewModel> _mockNavigationTreeViewModel;
        private Mock<IApplicationStateService> _mockApplicationStateService;

        [SetUp]
        public void SetUp()
        {
            _mockStartMenuViewModel = new Mock<IStartMenuViewModel>();
            _mockNavigationTreeViewModel = new Mock<INavigationTreeViewModel>();
            _mockApplicationStateService = new Mock<IApplicationStateService>();
            _viewModel = new NavigationPaneViewModel(
                _mockStartMenuViewModel.Object,
                _mockNavigationTreeViewModel.Object,
                _mockApplicationStateService.Object);
        }

        [Test]
        public void TestIsStartMenuVisibleShouldReturnState()
        {
            _mockApplicationStateService.Setup(p => p.IsStartMenuVisible).Returns(true);
            var result = _viewModel.IsStartMenuVisible;
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestGetStartMenuViewModelShouldReturnViewModel()
        {
            var result = _viewModel.StartMenuViewModel;
            Assert.That(result, Is.EqualTo(_mockStartMenuViewModel.Object));
        }

        [Test]
        public void TestIsNavigationTreeVisibleShouldReturnState()
        {
            _mockApplicationStateService.Setup(p => p.IsNavigationTreeVisible).Returns(true);
            var result = _viewModel.IsNavigationTreeVisible;
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestGetNavigationTreeViewModelShouldReturnViewModel()
        {
            var result = _viewModel.NavigationTreeViewModel;
            Assert.That(result, Is.EqualTo(_mockNavigationTreeViewModel.Object));
        }

        [Test]
        public void TestHandleApplicationStateChangedEventShouldNotifyIsStartMenuVisiblePropertyChanged()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) => { if (e.PropertyName == "IsStartMenuVisible") wasRaised = true; };
            _viewModel.Handle(new ApplicationStateChangedEvent());
            Assert.That(wasRaised, Is.True);
        }

        [Test]
        public void TestHandleApplicationStateChangedEventShouldNotifyIsNavigationTreeVisiblePropertyChanged()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) => { if (e.PropertyName == "IsNavigationTreeVisible") wasRaised = true; };
            _viewModel.Handle(new ApplicationStateChangedEvent());
            Assert.That(wasRaised, Is.True);
        }
    }
}
