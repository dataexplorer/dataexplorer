using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Layouts.Shape;
using DataExplorer.Application.Layouts.Shape.Commands;
using DataExplorer.Application.Layouts.Shape.Queries;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Layout;

namespace DataExplorer.Presentation.Panes.Layout.Shape
{
    public class ShapeLayoutViewModel
        : BaseViewModel, 
        IShapeLayoutViewModel,
        IEventHandler<LayoutChangedEvent>,
        IEventHandler<LayoutResetEvent>
    {
        private readonly IMessageBus _messageBus;
        private List<LayoutItemViewModel> _viewModels; 

        public ShapeLayoutViewModel(IMessageBus messageBus)
        {
            _messageBus = messageBus;

            _viewModels = new List<LayoutItemViewModel>();
        }

        public string Label
        {
            get { return "Shape"; }
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
            var columns = _messageBus.Execute(new GetAllShapeColumnsQuery());

            _viewModels = columns
                .Select(p => new LayoutItemViewModel(p))
                .ToList();

            _viewModels.Insert(0, new LayoutItemViewModel(null));

            return _viewModels;
        }

        private LayoutItemViewModel GetSelectedColumnViewModel()
        {
            var columnDto = _messageBus.Execute(new GetShapeColumnQuery());

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
                _messageBus.Execute(new UnsetShapeColumnCommand());
            else
                _messageBus.Execute(new SetShapeColumnCommand(value.Column.Id));
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
