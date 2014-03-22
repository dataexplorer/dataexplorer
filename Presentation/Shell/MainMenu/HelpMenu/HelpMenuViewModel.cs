using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Web.Commands;
using DataExplorer.Presentation.Core.Commands;
using ICommand = System.Windows.Input.ICommand;

namespace DataExplorer.Presentation.Shell.MainMenu.HelpMenu
{
    public class HelpMenuViewModel : IHelpMenuViewModel
    {
        private readonly ICommandBus _commandBus;
        private readonly ICommand _viewHelpCommand;
        private readonly ICommand _viewAboutCommand;

        public HelpMenuViewModel(ICommandBus commandBus)
        {
            _commandBus = commandBus;

            _viewHelpCommand = new DelegateCommand(ViewHelp);
            _viewAboutCommand = new DelegateCommand(ViewAbout);
        }

        public ICommand ViewHelpCommand 
        {
            get { return _viewHelpCommand; } 
        }

        public ICommand ViewAboutCommand
        {
            get { return _viewAboutCommand; }
        }

        private void ViewHelp(object obj)
        {
            _commandBus.Execute(new ViewHelpCommand());
        }

        private void ViewAbout(object obj)
        {
            _commandBus.Execute(new ViewAboutCommand());
        }
    }
}
