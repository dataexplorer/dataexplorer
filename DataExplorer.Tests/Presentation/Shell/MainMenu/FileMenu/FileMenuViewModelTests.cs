using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application;
using DataExplorer.Presentation.Shell.MainMenu.FileMenu;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Shell.MainMenu.FileMenu
{
    [TestFixture]
    public class FileMenuViewModelTests
    {
        [Test]
        public void TestExitCommandShouldExit()
        {
            var mockFileService = new Mock<IApplicationService>();
            var fileMenuViewModel = new FileMenuViewModel(mockFileService.Object);
            fileMenuViewModel.ExitCommand.Execute(null);
            mockFileService.Verify(p => p.Exit(), Times.Once());
        }
    }
}
