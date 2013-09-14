using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Events;
using DataExplorer.Application.Importers.CsvFile.Events;

namespace DataExplorer.Application.Application
{
    public class ApplicationStateService 
        : IApplicationStateService, 
        IAppHandler<CsvFileImportingEvent>,
        IAppHandler<CsvFileImportedEvent>
    {
        private readonly ApplicationState _state;

        public ApplicationStateService(ApplicationState state)
        {
            _state = state;
        }

        public ApplicationStateService()
        {
            _state = new ApplicationState();

            _state.IsStartMenuVisible = true;
            _state.IsNavigationTreeVisible = false;
        }

        public ApplicationState GetState()
        {
            return _state;
        }

        public void Handle(CsvFileImportingEvent args)
        {
            _state.IsStartMenuVisible = false;
            _state.IsNavigationTreeVisible = false;
            
            AppEvents.Raise(new ApplicationStateChangedEvent());
        }

        public void Handle(CsvFileImportedEvent args)
        {
            _state.IsStartMenuVisible = false;
            _state.IsNavigationTreeVisible = true;

            AppEvents.Raise(new ApplicationStateChangedEvent());
        }
    }
}
