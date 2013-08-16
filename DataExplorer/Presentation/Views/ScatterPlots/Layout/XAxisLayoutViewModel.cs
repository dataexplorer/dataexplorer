using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Layout;

namespace DataExplorer.Presentation.Views.ScatterPlots.Layout
{
    public class XAxisLayoutViewModel : BaseViewModel, IXAxisLayoutViewModel
    {
        private readonly IScatterPlotLayoutService _service;

        public XAxisLayoutViewModel(IScatterPlotLayoutService service)
        {
            _service = service;

            _service.LayoutColumnsChangedEvent += HandleLayoutColumnsChangeEvent;
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
            var columns = _service.GetColumns();

            var viewModels = columns
                .Select(p => new LayoutItemViewModel(p))
                .ToList();

            return viewModels;
        }

        private LayoutItemViewModel GetSelectedColumnViewModel()
        {
            var column = _service.GetXColumn();

            var viewModel = new LayoutItemViewModel(column);

            return viewModel;
        }

        private void SetSelectedColumnViewModel(LayoutItemViewModel value)
        {
            // TODO: Should this just return or set X Column to null?
            if (value == null)
                return;

            var column = value.Column;

            _service.SetXColumn(column);
        }

        private void HandleLayoutColumnsChangeEvent(object source, EventArgs eventArgs)
        {
            OnPropertyChanged(() => SelectedColumn);
            OnPropertyChanged(() => Columns);
        }
    }
}
