using DataExplorer.Application.Clipboard;
using DataExplorer.Application.Clipboard.Commands;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Rows;
using DataExplorer.Application.Rows.Events;
using DataExplorer.Presentation.Shell.MainMenu.EditMenu;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Shell.MainMenu.EditMenu
{
    [TestFixture]
    public class EditMenuViewModelTests
    {
        private EditMenuViewModel _viewModel;
        private Mock<IMessageBus> _mockMessageBus;

        [SetUp]
        public void SetUp()
        {
            _mockMessageBus = new Mock<IMessageBus>();

            _viewModel = new EditMenuViewModel(_mockMessageBus.Object);
        }

        [Test]
        public void TestExecuteCopyCommandShouldCopy()
        {
            _viewModel.CopyCommand.Execute(null);
            _mockMessageBus.Verify(p => p.Execute(It.IsAny<CopyDataToClipboardCommand>()), Times.Once());
        }

        [Test]
        public void TestExecuteCopyImageShouldCopyImage()
        {
            _viewModel.CopyImageCommand.Execute(null);
            _mockMessageBus.Verify(p => p.Execute(It.IsAny<CopyImageToClipboardCommand>()), Times.Once());
        }

        [Test]
        public void TestHandleSelectedRowsChangedShouldRaiseCanCopyChangedEvent()
        {
            var wasRaised = false;
            _viewModel.CopyCommand.CanExecuteChanged += (s, e) => wasRaised = true;
            _viewModel.Handle(new SelectedRowsChangedEvent());
            Assert.That(wasRaised, Is.True);
        }
    }
}
