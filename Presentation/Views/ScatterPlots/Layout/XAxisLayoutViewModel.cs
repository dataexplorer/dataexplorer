using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Application.Views.ScatterPlots.Events;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Layout;

namespace DataExplorer.Presentation.Views.ScatterPlots.Layout
{
    public class XAxisLayoutViewModel 
        : BaseViewModel, 
        IXAxisLayoutViewModel,
        IEventHandler<ScatterPlotLayoutChangedEvent>,
        IDomainHandler<ScatterPlotLayoutColumnChangedEvent>
    {
        private readonly IQueryBus _queryBus;
        private readonly IScatterPlotLayoutService _layoutService;
        
        public XAxisLayoutViewModel(
            IQueryBus queryBus,
            IScatterPlotLayoutService layoutService)
        {
            _queryBus = queryBus;
            _layoutService = layoutService;
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

        private List<LayoutItemViewModel> GetColumnViewModels()
        {
            var columns = _queryBus.Execute(new GetAllColumnsQuery());

            var viewModels = columns
                .Select(p => new LayoutItemViewModel(p))
                .ToList();

            return viewModels;
        }

        private LayoutItemViewModel GetSelectedColumnViewModel()
        {
            var columnDto = _layoutService.GetXColumn();

            if (columnDto == null)
                return null;

            var viewModel = new LayoutItemViewModel(columnDto);

            return viewModel;
        }

        private void SetSelectedColumnViewModel(LayoutItemViewModel value)
        {
            // TODO: Should this just return or set X Column to null?
            if (value == null)
                return;

            var column = value.Column;

            _layoutService.SetXColumn(column);
        }

        public void Handle(ScatterPlotLayoutChangedEvent args)
        {
            OnPropertyChanged(() => Columns);
            OnPropertyChanged(() => SelectedColumn);
        }

        public void Handle(ScatterPlotLayoutColumnChangedEvent args)
        {
            OnPropertyChanged(() => SelectedColumn);
        }
    }
}
