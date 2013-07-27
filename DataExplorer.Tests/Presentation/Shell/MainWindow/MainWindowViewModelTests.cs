using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private MainWindowViewModel _mainWindowViewModel;
        private Mock<IMainMenuViewModel> _mockMainMenuViewModel;
        private Mock<IViewerPaneViewModel> _mockViewerViewModel;

        [SetUp]
        public void SetUp()
        {
            _mockViewerViewModel = new Mock<IViewerPaneViewModel>();
            _mockMainMenuViewModel = new Mock<IMainMenuViewModel>();
            _mainWindowViewModel = new MainWindowViewModel(
                _mockMainMenuViewModel.Object, 
                _mockViewerViewModel.Object);
        }

        [Test]
        public void TestGetMainMenuViewModelShouldReturnMainMenuViewModel()
        {
            Assert.That(_mainWindowViewModel.MainMenuViewModel, Is.EqualTo(_mockMainMenuViewModel.Object));
        }

        [Test]
        public void TestGetViewerViewModelShouldReturnViewerViewModel()
        {
            Assert.That(_mainWindowViewModel.ViewerPaneViewModel, Is.EqualTo(_mockViewerViewModel.Object));
        }
    }
}
