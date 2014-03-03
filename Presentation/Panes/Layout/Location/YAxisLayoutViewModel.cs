using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Layouts.Location.Commands;
using DataExplorer.Application.Layouts.Location.Queries;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Layout;

namespace DataExplorer.Presentation.Panes.Layout.Location
{
    public class YAxisLayoutViewModel 
        : BaseViewModel, 
        IYAxisLayoutViewModel,
        IEventHandler<LayoutChangedEvent>,
        IEventHandler<LayoutResetEvent>
    {
        private readonly IMessageBus _messageBus;
        private List<LayoutItemViewModel> _viewModels; 

        public YAxisLayoutViewModel(IMessageBus messageBus)
        {
            _messageBus = messageBus;

            _viewModels = new List<LayoutItemViewModel>();
        }

        public string Label
        {
            get { return "y-Axis"; }
        }

        public List<LayoutItemViewModel> Columns
        {
            get { return GetColumnViewModels(); }
        }

        public LayoutItemViewModel SelectedColumn
        {
            get { return GetSelectedColumnViewModel(); }
            set { SetSelectedColumnViewModel(value); }
        }

        private List<LayoutItemViewModel> GetColumnViewModels()
        {
            var columns = _messageBus.Execute(new GetAllColumnsQuery());

            _viewModels = columns
                .Select(p => new LayoutItemViewModel(p))
                .ToList();

            _viewModels.Insert(0, new LayoutItemViewModel(null));

            return _viewModels;
        }

        private LayoutItemViewModel GetSelectedColumnViewModel()
        {
            var columnDto = _messageBus.Execute(new GetYColumnQuery());

            if (columnDto == null)
                return null;

            var viewModel = new LayoutItemViewModel(columnDto);

            return viewModel;
        }

        private void SetSelectedColumnViewModel(LayoutItemViewModel value)
        {
            if (value.Column == null)
                _messageBus.Execute(new UnsetYAxisColumnCommand());
            else
                _messageBus.Execute(new SetYAxisColumnCommand(value.Column.Id));
        }

        public void Handle(LayoutChangedEvent args)
        {
            OnPropertyChanged(() => SelectedColumn);
        }

        public void Handle(LayoutResetEvent args)
        {
            OnPropertyChanged(() => Columns);
            OnPropertyChanged(() => SelectedColumn);
        }
    }
}
