using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Application.Commands;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Layouts.General.Commands;
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

        public ICommand ShowNavigationPaneCommand
        {
            get { return new DelegateCommand(p => _commandBus.Execute(new ShowPaneCommand(Pane.Navigation))); }
        }

        public ICommand ShowFilterPaneCommand
        {
            get { return new DelegateCommand(p => _commandBus.Execute(new ShowPaneCommand(Pane.Filter))); }
        }
        
        public ICommand ShowLayoutPaneCommand
        {
            get { return new DelegateCommand(p => _commandBus.Execute(new ShowPaneCommand(Pane.Layout))); }
        }
        
        public ICommand ShowLegendPaneCommand
        {
            get { return new DelegateCommand(p => _commandBus.Execute(new ShowPaneCommand(Pane.Legend))); }
        }
        
        public ICommand ShowPropertyPaneCommand
        {
            get { return new DelegateCommand(p => _commandBus.Execute(new ShowPaneCommand(Pane.Property))); }
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
