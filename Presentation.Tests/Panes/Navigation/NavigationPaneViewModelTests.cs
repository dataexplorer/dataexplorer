using DataExplorer.Application.Application;
using DataExplorer.Application.Application.Events;
using DataExplorer.Presentation.Panes.Navigation;
using DataExplorer.Presentation.Panes.Navigation.NavigationTree;
using DataExplorer.Presentation.Panes.Navigation.StartMenu;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Navigation
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
            _mockApplicationStateService.Setup(p => p.GetIsStartMenuVisible()).Returns(true);
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
            _mockApplicationStateService.Setup(p => p.GetIsNavigationTreeVisible()).Returns(true);
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
        public void TestHandleStartMenuVisibilityChangedEventShouldNotifyIsStartMenuVisiblePropertyChanged()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) => { if (e.PropertyName == "IsStartMenuVisible") wasRaised = true; };
            _viewModel.Handle(new StartMenuVisibilityChangedEvent());
            Assert.That(wasRaised, Is.True);
        }

        [Test]
        public void TestHandleNavigationTreeVisibilityChangedEventShouldNotifyIsNavigationTreeVisiblePropertyChanged()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) => { if (e.PropertyName == "IsNavigationTreeVisible") wasRaised = true; };
            _viewModel.Handle(new NavigationTreeVisibilityChangedEvent());
            Assert.That(wasRaised, Is.True);
        }
    }
}
