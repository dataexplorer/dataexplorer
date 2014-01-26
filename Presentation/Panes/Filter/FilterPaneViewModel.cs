using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Filters.Events;
using DataExplorer.Application.Filters.Queries;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Presentation.Core;

namespace DataExplorer.Presentation.Panes.Filter
{
    public class FilterPaneViewModel
        : BaseViewModel, 
        IFilterPaneViewModel,
        IEventHandler<FilterAddedEvent>,
        IEventHandler<FilterRemovedEvent>,
        IEventHandler<ProjectOpeningEvent>,
        IEventHandler<ProjectOpenedEvent>,
        IEventHandler<ProjectClosedEvent>,
        IEventHandler<CsvFileImportingEvent>,
        IEventHandler<CsvFileImportedEvent>
    {
        private readonly IQueryBus _queryBus;
        private readonly IFilterViewModelFactory _factory;
        
        public FilterPaneViewModel(
            IQueryBus queryBus, 
            IFilterViewModelFactory factory)
        {
            _queryBus = queryBus;
            _factory = factory;
        }

        public List<FilterViewModel> FilterViewModels
        {
            get { return GetFilterViewModels(); }
        }

        public void Handle(FilterAddedEvent args)
        {
            OnPropertyChanged(() => FilterViewModels);
        }

        public void Handle(FilterRemovedEvent args)
        {
            OnPropertyChanged(() => FilterViewModels);
        }

        public void Handle(ProjectOpeningEvent args)
        {
            OnPropertyChanged(() => FilterViewModels);
        }

        public void Handle(ProjectOpenedEvent args)
        {
            OnPropertyChanged(() => FilterViewModels);
        }

        public void Handle(ProjectClosedEvent args)
        {
            OnPropertyChanged(() => FilterViewModels);
        }

        public void Handle(CsvFileImportingEvent args)
        {
            OnPropertyChanged(() => FilterViewModels);
        }

        public void Handle(CsvFileImportedEvent args)
        {
            OnPropertyChanged(() => FilterViewModels);
        }

        private List<FilterViewModel> GetFilterViewModels()
        {
            var filters = _queryBus.Execute(new GetFiltersQuery());

            var viewModels = filters
                .Select(p => _factory.Create(p))
                .ToList();

            return viewModels;
        }
    }
}
