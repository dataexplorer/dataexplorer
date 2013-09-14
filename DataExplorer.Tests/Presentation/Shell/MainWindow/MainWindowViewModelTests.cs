using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Panes.Layout;
using DataExplorer.Presentation.Panes.Navigation;
using DataExplorer.Presentation.Panes.Viewer;
using DataExplorer.Presentation.Shell.MainMenu;
using DataExplorer.Presentation.Shell.MainWindow;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Shell.MainWindow
{
    [TestFixture]
    public class MainWindowViewModelTests
    {
        private MainWindowViewModel _viewModel;
        private Mock<IMainMenuViewModel> _mockMainMenuViewModel;
        private Mock<INavigationPaneViewModel> _mockNavigationPaneViewModel;
        private Mock<IViewerPaneViewModel> _mockViewerViewModel;
        private Mock<ILayoutPaneViewModel> _mockLayoutPaneViewModel;

        [SetUp]
        public void SetUp()
        {
            _mockViewerViewModel = new Mock<IViewerPaneViewModel>();
            _mockMainMenuViewModel = new Mock<IMainMenuViewModel>();
            _mockNavigationPaneViewModel = new Mock<INavigationPaneViewModel>();
            _mockLayoutPaneViewModel = new Mock<ILayoutPaneViewModel>();
            _viewModel = new MainWindowViewModel(
                _mockMainMenuViewModel.Object,
                _mockNavigationPaneViewModel.Object,
                _mockViewerViewModel.Object,
                _mockLayoutPaneViewModel.Object);
        }

        [Test]
        public void TestGetMainMenuViewModelShouldReturnMainMenuViewModel()
        {
            var result = _viewModel.MainMenuViewModel;
            Assert.That(result, Is.EqualTo(_mockMainMenuViewModel.Object));
        }

        [Test]
        public void TestGetNavigationPaneViewModelShouldReturnViewModel()
        {
            var result = _viewModel.NavigationPaneViewModel;
            Assert.That(result, Is.EqualTo(_mockNavigationPaneViewModel.Object));
        }

        [Test]
        public void TestGetViewerViewModelShouldReturnViewerViewModel()
        {
            var result = _viewModel.ViewerPaneViewModel;
            Assert.That(result, Is.EqualTo(_mockViewerViewModel.Object));
        }

        [Test]
        public void TestGetLayoutPaneViewModelShouldReturnLayoutPaneViewModel()
        {
            var result = _viewModel.LayoutPaneViewModel;
            Assert.That(result, Is.EqualTo(_mockLayoutPaneViewModel.Object));
        }
    }
}
