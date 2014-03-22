using DataExplorer.Presentation.Shell.MainMenu;
using DataExplorer.Presentation.Shell.MainMenu.EditMenu;
using DataExplorer.Presentation.Shell.MainMenu.FileMenu;
using DataExplorer.Presentation.Shell.MainMenu.HelpMenu;
using DataExplorer.Presentation.Shell.MainMenu.ViewMenu;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Shell.MainMenu
{
    [TestFixture]
    public class MainMenuViewModelTests
    {
        private MainMenuViewModel _mainMenuViewModel;
        private Mock<IFileMenuViewModel> _mockFileMenuViewModel;
        private Mock<IEditMenuViewModel> _mockEditMenuViewModel;
        private Mock<IViewMenuViewModel> _mockViewMenuViewModel;
        private Mock<IHelpMenuViewModel> _mockHelpMenuViewModel;

        [SetUp]
        public void SetUp()
        {
            _mockFileMenuViewModel = new Mock<IFileMenuViewModel>();
            _mockEditMenuViewModel = new Mock<IEditMenuViewModel>();
            _mockViewMenuViewModel = new Mock<IViewMenuViewModel>();
            _mockHelpMenuViewModel = new Mock<IHelpMenuViewModel>();

            _mainMenuViewModel = new MainMenuViewModel(
                _mockFileMenuViewModel.Object,
                _mockEditMenuViewModel.Object,
                _mockViewMenuViewModel.Object,
                _mockHelpMenuViewModel.Object);
        }

        [Test]
        public void TestGetFileMenuViewModelShouldReturnFileMenuViewModel()
        {
            var result = _mainMenuViewModel.FileMenuViewModel;
            Assert.That(result, Is.EqualTo(_mockFileMenuViewModel.Object));
        }

        [Test]
        public void TestGetEditMenuViewModelShouldReturnEditMenuViewModel()
        {
            var result = _mainMenuViewModel.EditMenuViewModel;
            Assert.That(result, Is.EqualTo(_mockEditMenuViewModel.Object));
        }

        [Test]
        public void TestGetViewMenuViewModelShouldReturnViewModel()
        {
            var result = _mainMenuViewModel.ViewMenuViewModel;
            Assert.That(result, Is.EqualTo(_mockViewMenuViewModel.Object));
        }

        [Test]
        public void TestGetHelpMenuViewModelShouldReturnViewModel()
        {
            var result = _mainMenuViewModel.HelpMenuViewModel;
            Assert.That(result, Is.EqualTo(_mockHelpMenuViewModel.Object));
        }
    }
}
