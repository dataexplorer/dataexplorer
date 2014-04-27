using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Layouts.Location.Commands;
using DataExplorer.Application.Layouts.Location.Queries;
using DataExplorer.Domain.Layouts;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Commands;
using DataExplorer.Presentation.Core.Layout;

namespace DataExplorer.Presentation.Panes.Layout.Location
{
    public class XAxisLayoutViewModel 
        : BaseViewModel, 
        IXAxisLayoutViewModel,
        IEventHandler<LayoutChangedEvent>,
        IEventHandler<LayoutResetEvent>
    {
        private readonly IMessageBus _messageBus;
        private readonly DelegateCommand _sortCommand;
        
        public XAxisLayoutViewModel(IMessageBus messageBus)
        {
            _messageBus = messageBus;

            _sortCommand = new DelegateCommand(ToggleSortOrder);
        }

        public string Label
        {
            get { return "x-Axis"; }
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

        public string SortCommandText
        {
            get { return GetSortCommandText(); }
        }

        public ICommand SortCommand
        {
            get { return _sortCommand; }
        }

        private List<LayoutItemViewModel> GetColumnViewModels()
        {
            var columns = _messageBus.Execute(new GetAllColumnsQuery());

            var viewModels = columns
                .Select(p => new LayoutItemViewModel(p))
                .ToList();

            viewModels.Insert(0, new LayoutItemViewModel(null));

            return viewModels;
        }

        private LayoutItemViewModel GetSelectedColumnViewModel()
        {
            var columnDto = _messageBus.Execute(new GetXAxisColumnQuery());

            if (columnDto == null)
                return null;

            var viewModel = new LayoutItemViewModel(columnDto);

            return viewModel;
        }

        private void SetSelectedColumnViewModel(LayoutItemViewModel value)
        {
            if (value == null)
                return;

            if (value.Column == null)
                _messageBus.Execute(new UnsetXAxisColumnCommand());
            else
                _messageBus.Execute(new SetXAxisColumnCommand(value.Column.Id));
        }

        private string GetSortCommandText()
        {
            var sortOrder = _messageBus.Execute(new GetXAxisSortOrderQuery());

            return sortOrder == SortOrder.Ascending
                ? "Sort " + SortOrder.Descending
                : "Sort " + SortOrder.Ascending;
        }

        private void ToggleSortOrder(object parameters)
        {
            var oldSortOrder = _messageBus.Execute(new GetXAxisSortOrderQuery());

            var newSortOrder = oldSortOrder == SortOrder.Ascending
                ? SortOrder.Descending
                : SortOrder.Ascending;

            _messageBus.Execute(new SetXAxisSetSortOrderCommand(newSortOrder));
        }

        public void Handle(LayoutChangedEvent args)
        {
            OnPropertyChanged(() => SelectedColumn);
            OnPropertyChanged(() => SortCommandText);
        }

        public void Handle(LayoutResetEvent args)
        {
            OnPropertyChanged(() => Columns);
            OnPropertyChanged(() => SelectedColumn);
            OnPropertyChanged(() => SortCommandText);
        }
    }
}
