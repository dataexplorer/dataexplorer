using System;
using System.Collections.ObjectModel;
using System.Linq;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Filters.Events;
using DataExplorer.Presentation.Core;

namespace DataExplorer.Presentation.Panes.Filter
{
    public class FilterPaneViewModel
        : BaseViewModel, 
        IFilterPaneViewModel,
        IEventHandler<FilterAddedEvent>,
        IEventHandler<FilterRemovedEvent>
    {
        private readonly IFilterViewModelFactory _factory;
        private readonly ObservableCollection<FilterViewModel> _filterViewModels;

        public FilterPaneViewModel(IFilterViewModelFactory factory)
        {
            _factory = factory;
            _filterViewModels = new ObservableCollection<FilterViewModel>();
        }

        public ObservableCollection<FilterViewModel> FilterViewModels
        {
            get { return _filterViewModels; }
        }

        public void Handle(FilterAddedEvent args)
        {
            var filterViewModel = _factory.Create(args.Filter);

            _filterViewModels.Add(filterViewModel);

            OnPropertyChanged(() => FilterViewModels);
        }

        public void Handle(FilterRemovedEvent args)
        {
            var filterViewModel = _filterViewModels
                .First(p => p.Filter == args.Filter);

            _filterViewModels.Remove(filterViewModel);
        }
    }
}
