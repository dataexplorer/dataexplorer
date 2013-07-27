using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Shell.MainMenu;
using DataExplorer.Presentation.Shell.MainMenu.FileMenu;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Shell.MainMenu
{
    [TestFixture]
    public class MainMenuViewModelTests
    {
        [Test]
        public void TestGetFileMenuViewModelShouldReturnFileMenuViewModel()
        {
            var mockFileMenuViewModel = new Mock<IFileMenuViewModel>();
            var mainMenuViewModel = new MainMenuViewModel(mockFileMenuViewModel.Object);
            Assert.That(mainMenuViewModel.FileMenuViewModel, Is.EqualTo(mockFileMenuViewModel.Object));
        }
    }
}
