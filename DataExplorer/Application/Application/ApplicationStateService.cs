using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Application.Events;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Application.Application
{
    public class ApplicationStateService 
        : IApplicationStateService, 
        IEventHandler<CsvFileImportingEvent>,
        IEventHandler<CsvFileImportedEvent>
    {
        private readonly ApplicationState _state;
        private readonly IEventBus _eventBus;

        public ApplicationStateService(
            ApplicationState state,
            IEventBus eventBus)
        {
            _state = state;
            _eventBus = eventBus;
        }

        public ApplicationStateService()
        {
            _state = new ApplicationState();
            _eventBus = new EventBus();

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

        public List<Row> SelectedRows
        {
            get { return _state.SelectedRows; }
            set { _state.SelectedRows = value; }
        }

        public void Handle(CsvFileImportingEvent args)
        {
            _state.IsStartMenuVisible = false;
            _state.IsNavigationTreeVisible = false;
            
            _eventBus.Raise(new ApplicationStateChangedEvent());
        }

        public void Handle(CsvFileImportedEvent args)
        {
            _state.IsStartMenuVisible = false;
            _state.IsNavigationTreeVisible = true;

            _eventBus.Raise(new ApplicationStateChangedEvent());
        }
    }
}
