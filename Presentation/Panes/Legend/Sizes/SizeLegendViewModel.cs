using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Layouts.Size.Queries;
using DataExplorer.Application.Legends.Sizes.Queries;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Presentation.Core;

namespace DataExplorer.Presentation.Panes.Legend.Sizes
{
    public class SizeLegendViewModel
        : BaseViewModel,
        ISizeLegendViewModel,
        IEventHandler<ProjectOpenedEvent>,
        IEventHandler<ProjectClosedEvent>,
        IEventHandler<SourceImportedEvent>,
        IEventHandler<LayoutChangedEvent>
    {
        private readonly IQueryBus _queryBus;

        public SizeLegendViewModel(IQueryBus queryBus)
        {
            _queryBus = queryBus;
        }

        public string Title
        {
            get { return GetTitle(); }
        }

        public List<SizeLegendItemViewModel> Items
        {
            get { return GetItems(); }
        }

        private string GetTitle()
        {
            var column = _queryBus.Execute(new GetSizeColumnQuery());

            if (column == null)
                return string.Empty;

            return column.Name;
        }

        private List<SizeLegendItemViewModel> GetItems()
        {
            var items = _queryBus.Execute(new GetSizeLegendItemsQuery());

            var viewModels = items.Select(p => new SizeLegendItemViewModel(p.Size, p.Label));

            return viewModels.ToList();
        }

        public void Handle(ProjectOpenedEvent args)
        {
            OnPropertyChanged(() => Title);
            OnPropertyChanged(() => Items);
        }

        public void Handle(ProjectClosedEvent args)
        {
            OnPropertyChanged(() => Title);
            OnPropertyChanged(() => Items);
        }

        public void Handle(SourceImportedEvent args)
        {
            OnPropertyChanged(() => Title);
            OnPropertyChanged(() => Items);
        }

        public void Handle(LayoutChangedEvent args)
        {
            OnPropertyChanged(() => Title);
            OnPropertyChanged(() => Items);
        }
    }
}
