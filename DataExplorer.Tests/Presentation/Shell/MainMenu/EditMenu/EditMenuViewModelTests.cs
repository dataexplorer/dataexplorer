using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Clipboard;
using DataExplorer.Presentation.Shell.MainMenu.EditMenu;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Shell.MainMenu.EditMenu
{
    [TestFixture]
    public class EditMenuViewModelTests
    {
        private EditMenuViewModel _viewModel;
        private Mock<IClipboardService> _mockClipboard;

        [SetUp]
        public void SetUp()
        {
            _mockClipboard = new Mock<IClipboardService>();

            _viewModel = new EditMenuViewModel(_mockClipboard.Object);
        }

        [Test]
        public void TestExecuteCopyCommandShouldCopy()
        {
            _viewModel.CopyCommand.Execute(null);
            _mockClipboard.Verify(p => p.Copy(), Times.Once());
        }
    }
}
