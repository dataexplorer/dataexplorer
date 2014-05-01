using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Layouts.Color.Commands;
using DataExplorer.Application.Layouts.Color.Queries;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Domain.Layouts;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Commands;
using DataExplorer.Presentation.Core.Layout;

namespace DataExplorer.Presentation.Panes.Layout.Color
{
    public class ColorLayoutViewModel 
        : BaseViewModel, 
        IColorLayoutViewModel,
        IEventHandler<LayoutChangedEvent>,
        IEventHandler<LayoutResetEvent>
    {
        private readonly IMessageBus _messageBus;
        private readonly DelegateCommand _sortCommand;

        public ColorLayoutViewModel(IMessageBus messageBus)
        {
            _messageBus = messageBus;

            _sortCommand = new DelegateCommand(ToggleSortOrder);
        }

        public string Label
        {
            get { return "Color"; }
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

        public List<ColorPaletteViewModel> ColorPalettes
        {
            get { return GetColorPaletteViewModels(); }
        }

        public ColorPaletteViewModel SelectedColorPalette
        {
            get { return GetSelectedColorPaletteViewModel(); }
            set { SetSelectedColorPaletteViewModel(value); }
        }

        private List<LayoutItemViewModel> GetColumnViewModels()
        {
            var columns = _messageBus.Execute(new GetAllColorColumnsQuery());

            var viewModels = columns
                .Select(p => new LayoutItemViewModel(p))
                .ToList();

            viewModels.Insert(0, new LayoutItemViewModel(null));

            return viewModels;
        }

        private LayoutItemViewModel GetSelectedColumnViewModel()
        {
            var columnDto = _messageBus.Execute(new GetColorColumnQuery());

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
                _messageBus.Execute(new UnsetColorColumnCommand());
            else
                _messageBus.Execute(new SetColorColumnCommand(value.Column.Id));
        }

        private string GetSortCommandText()
        {
            var sortOrder = _messageBus.Execute(new GetColorSortOrderQuery());

            return sortOrder == SortOrder.Ascending
                ? "Sort " + SortOrder.Descending
                : "Sort " + SortOrder.Ascending;
        }

        private void ToggleSortOrder(object parameters)
        {
            var oldSortOrder = _messageBus.Execute(new GetColorSortOrderQuery());

            var newSortOrder = oldSortOrder == SortOrder.Ascending
                ? SortOrder.Descending
                : SortOrder.Ascending;

            _messageBus.Execute(new SetColorSortOrderCommand(newSortOrder));
        }

        private List<ColorPaletteViewModel> GetColorPaletteViewModels()
        {
            var colorPalettes = _messageBus.Execute(new GetAllColorPalettesQuery());

            var viewModels = colorPalettes
                .Select(p => new ColorPaletteViewModel(p))
                .ToList();

            return viewModels;
        }

        private ColorPaletteViewModel GetSelectedColorPaletteViewModel()
        {
            var colorPalette = _messageBus.Execute(new GetColorPaletteQuery());

            if (colorPalette == null)
                return null;

            var viewModel = new ColorPaletteViewModel(colorPalette);

            return viewModel;
        }

        private void SetSelectedColorPaletteViewModel(ColorPaletteViewModel viewModel)
        {
            if (viewModel == null)
                return;

            var colorPalette = viewModel.ColorPalette;

            _messageBus.Execute(new SetColorPaletteCommand(colorPalette));
        }

        public void Handle(LayoutChangedEvent args)
        {
            OnPropertyChanged(() => SelectedColumn);
            OnPropertyChanged(() => SelectedColorPalette);
            OnPropertyChanged(() => SortCommandText);
        }

        public void Handle(LayoutResetEvent args)
        {
            OnPropertyChanged(() => Columns);
            OnPropertyChanged(() => SelectedColumn);
            OnPropertyChanged(() => SelectedColorPalette);
            OnPropertyChanged(() => SortCommandText);
        }
    }
}
