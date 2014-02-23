using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Layouts.Commands;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Application.Views.ScatterPlots.Commands;
using DataExplorer.Presentation.Core.Commands;
using ICommand = System.Windows.Input.ICommand;

namespace DataExplorer.Presentation.Shell.MainMenu.ViewMenu
{
    public class ViewMenuViewModel : IViewMenuViewModel
    {
        private readonly ICommandBus _commandBus;
        
        public ViewMenuViewModel(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        public ICommand ZoomToFullExtentCommand 
        {
            get { return new DelegateCommand(p => _commandBus.Execute(new ZoomToFullExtentCommand())); }
        }

        public ICommand ClearLayoutCommand
        {
            get { return new DelegateCommand(p => _commandBus.Execute(new ClearLayoutCommand())); }
        }
    }
}
