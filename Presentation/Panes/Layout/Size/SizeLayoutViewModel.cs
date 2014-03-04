using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Layouts.Size.Commands;
using DataExplorer.Application.Layouts.Size.Queries;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Layout;

namespace DataExplorer.Presentation.Panes.Layout.Size
{
    public class SizeLayoutViewModel
        : BaseViewModel,
        ISizeLayoutViewModel,
        IEventHandler<LayoutChangedEvent>,
        IEventHandler<LayoutResetEvent>
    {
         private readonly IMessageBus _messageBus;

        public SizeLayoutViewModel(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public string Label
        {
            get { return "Size"; }
        }

        public IEnumerable<LayoutItemViewModel> Columns
        {
            get { return GetColumnViewModels(); }
        }

        public LayoutItemViewModel SelectedColumn
        {
            get { return GetSelectedColumnViewModel(); }
            set { SetSelectedColumnViewModel(value); }
        }

        public bool IsLowerSizeSliderVisible
        {
            get { return GetIsLowerSizeSliderVisible(); }
        }

        public double MinSizeSliderValue
        {
            get { return 0d; }
        }

        public double MaxSizeSliderValue
        {
            get { return 1d; }
        }

        public double LowerSizeSliderValue
        {
            get { return GetLowerSizeSliderValue(); }
            set { SetLowerSizeSliderValue(value); }
        }

        public double UpperSizeSliderValue
        {
            get { return GetUpperSizeSliderValue(); }
            set { SetUpperSizeSliderValue(value); }
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
            var columnDto = _messageBus.Execute(new GetSizeColumnQuery());

            if (columnDto == null)
                return null;

            var viewModel = new LayoutItemViewModel(columnDto);
            
            return viewModel;
        }

        private void SetSelectedColumnViewModel(LayoutItemViewModel value)
        {
            if (value.Column == null)
                _messageBus.Execute(new UnsetSizeColumnCommand());
            else
                _messageBus.Execute(new SetSizeColumnCommand(value.Column.Id));

        }

        private bool GetIsLowerSizeSliderVisible()
        {
            var columnDto = _messageBus.Execute(new GetSizeColumnQuery());

            return columnDto != null;
        }

        private double GetLowerSizeSliderValue()
        {
            return _messageBus.Execute(new GetLowerSizeQuery());
        }

        private void SetLowerSizeSliderValue(double value)
        {
            _messageBus.Execute(new SetLowerSizeCommand(value));
        }

        private double GetUpperSizeSliderValue()
        {
            return _messageBus.Execute(new GetUpperSizeQuery());
        }

        private void SetUpperSizeSliderValue(double value)
        {
            _messageBus.Execute(new SetUpperSizeCommand(value));
        }

        public void Handle(LayoutChangedEvent args)
        {
            OnPropertyChanged(() => SelectedColumn);
            OnPropertyChanged(() => IsLowerSizeSliderVisible);
            OnPropertyChanged(() => LowerSizeSliderValue);
            OnPropertyChanged(() => UpperSizeSliderValue);
        }

        public void Handle(LayoutResetEvent args)
        {
            OnPropertyChanged(() => Columns);
            OnPropertyChanged(() => SelectedColumn);
            OnPropertyChanged(() => IsLowerSizeSliderVisible);
            OnPropertyChanged(() => LowerSizeSliderValue);
            OnPropertyChanged(() => UpperSizeSliderValue);
        }
    }
}
