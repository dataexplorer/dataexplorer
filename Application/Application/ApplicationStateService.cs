using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Application.Events;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Application.Application
{
    public class ApplicationStateService 
        : IApplicationStateService, 
        IEventHandler<ProjectOpeningEvent>,
        IEventHandler<ProjectOpenedEvent>,
        IEventHandler<ProjectClosedEvent>,
        IEventHandler<CsvFileImportingEvent>,
        IEventHandler<CsvFileImportedEvent>

    {
        private readonly IApplicationState _state;
        private readonly IEventBus _eventBus;

        public ApplicationStateService(
            IApplicationState state,
            IEventBus eventBus)
        {
            _state = state;
            _eventBus = eventBus;
        }

        public bool GetIsStartMenuVisible()
        {
            return _state.IsStartMenuVisible;
        }

        public void SetIsStartMenuVisible(bool isVisible)
        {
            _state.IsStartMenuVisible = isVisible;

            // TODO: Move this into an application-level event handler
            _eventBus.Raise(new StartMenuVisibilityChangedEvent());
        }

        public bool GetIsNavigationTreeVisible()
        {
            return _state.IsNavigationTreeVisible;
        }

        public void SetIsNavigationTreeVisible(bool isVisible)
        {
            _state.IsNavigationTreeVisible = isVisible;

            // TODO: Move this into an application-level event handler
            _eventBus.Raise(new NavigationTreeVisibilityChangedEvent());
        }

        public Filter GetSelectedFilter()
        {
            return _state.SelectedFilter;
        }

        public void SetSelectedFilter(Filter filter)
        {
            _state.SelectedFilter = filter;
        }

        public List<Row> GetSelectedRows()
        {
             return _state.SelectedRows;
        }

        public void SetSelectedRows(List<Row> rows)
        {
            _state.SelectedRows = rows;
        }

        // TODO: Move this into an application-level event handler
        public void Handle(ProjectOpeningEvent args)
        {
            SetIsStartMenuVisible(false);
            SetIsNavigationTreeVisible(false);
            SetSelectedFilter(null);
            SetSelectedRows(new List<Row>());
        }

        // TODO: Move this into an application-level event handler
        public void Handle(ProjectOpenedEvent args)
        {
            SetIsNavigationTreeVisible(true);
        }

        // TODO: Move this into an application-level event handler
        public void Handle(ProjectClosedEvent args)
        {
            SetIsStartMenuVisible(true);
            SetIsNavigationTreeVisible(false);
            SetSelectedFilter(null);
            SetSelectedRows(new List<Row>());
        }

        // TODO: Move this into an application-level event handler
        public void Handle(CsvFileImportingEvent args)
        {
            SetIsStartMenuVisible(false);
            SetIsNavigationTreeVisible(false);
            SetSelectedFilter(null);
            SetSelectedRows(new List<Row>());
        }

        // TODO: Move this into an application-level event handler
        public void Handle(CsvFileImportedEvent args)
        {
            SetIsNavigationTreeVisible(true);
        }
    }
}
