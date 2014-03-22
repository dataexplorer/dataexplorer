using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Web.Commands;
using DataExplorer.Presentation.Shell.MainMenu.HelpMenu;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Shell.MainMenu.HelpMenu
{
    [TestFixture]
    public class HelpMenuViewModelTests
    {
        private HelpMenuViewModel _viewModel;
        private Mock<ICommandBus> _mockCommandBus;

        [SetUp]
        public void SetUp()
        {
            _mockCommandBus = new Mock<ICommandBus>();

            _viewModel = new HelpMenuViewModel(
                _mockCommandBus.Object);
        }

        [Test]
        public void TestViewHelpShouldExecuteViewHelpCommand()
        {
            _viewModel.ViewHelpCommand.Execute(null);
            _mockCommandBus.Verify(p => p.Execute(It.IsAny<ViewHelpCommand>()));
        }

        [Test]
        public void TestViewAboutShouldExecuteViewAboutCommand()
        {
            _viewModel.ViewAboutCommand.Execute(null);
            _mockCommandBus.Verify(p => p.Execute(It.IsAny<ViewAboutCommand>()));
        }
    }
}
