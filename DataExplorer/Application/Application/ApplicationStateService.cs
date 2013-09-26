using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers.CsvFile.Events;
using DataExplorer.Domain.Filters;

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
            _state.SelectedFilter = null;
        }

        public bool IsStartMenuVisible
        {
            get { return _state.IsStartMenuVisible; }
            //set { _state.IsStartMenuVisible = value; }
        }

        public bool IsNavigationTreeVisible
        {
            get { return _state.IsNavigationTreeVisible; }
        }

        public Filter SelectedFilter
        {
            get { return _state.SelectedFilter; }
            set { _state.SelectedFilter = value; }
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
