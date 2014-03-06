using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Layouts.Label.Commands;
using DataExplorer.Application.Layouts.Label.Queries;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Layout;

namespace DataExplorer.Presentation.Panes.Layout.Label
{
    public class LabelLayoutViewModel
        : BaseViewModel, 
        ILabelLayoutViewModel,
        IEventHandler<LayoutChangedEvent>,
        IEventHandler<LayoutResetEvent>
    {
        private readonly IMessageBus _messageBus;
        
        public LabelLayoutViewModel(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public string Label
        {
            get { return "Label"; }
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

            var viewModels = columns
                .Select(p => new LayoutItemViewModel(p))
                .ToList();

            viewModels.Insert(0, new LayoutItemViewModel(null));

            return viewModels;
        }

        private LayoutItemViewModel GetSelectedColumnViewModel()
        {
            var columnDto = _messageBus.Execute(new GetLabelColumnQuery());

            if (columnDto == null)
                return null;

            var viewModel = new LayoutItemViewModel(columnDto);

            return viewModel;
        }

        private void SetSelectedColumnViewModel(LayoutItemViewModel value)
        {
            if (value.Column == null)
                _messageBus.Execute(new UnsetLabelColumnCommand());
            else
                _messageBus.Execute(new SetLabelColumnCommand(value.Column.Id));
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
