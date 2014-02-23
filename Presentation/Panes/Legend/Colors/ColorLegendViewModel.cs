using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Layouts.Events;
using DataExplorer.Application.Layouts.Queries;
using DataExplorer.Application.Legends.Colors.Queries;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Presentation.Core;

namespace DataExplorer.Presentation.Panes.Legend.Colors
{
    public class ColorLegendViewModel 
        : BaseViewModel,
        IColorLegendViewModel,
        IEventHandler<ProjectOpenedEvent>,
        IEventHandler<ProjectClosedEvent>,
        IEventHandler<SourceImportedEvent>,
        IEventHandler<LayoutChangedEvent>
    {
        private readonly IQueryBus _queryBus;

        public ColorLegendViewModel(IQueryBus queryBus)
        {
            _queryBus = queryBus;
        }

        public string Title
        {
            get { return GetTitle(); }
        }

        public List<ColorLegendItemViewModel> Items
        {
            get { return GetItems(); }
        }

        private string GetTitle()
        {
            var column = _queryBus.Execute(new GetColorColumnQuery());

            if (column == null)
                return string.Empty;

            return column.Name;
        }

        private List<ColorLegendItemViewModel> GetItems()
        {
            var items = _queryBus.Execute(new GetColorLegendItemsQuery());

            var viewModels = items.Select(p => new ColorLegendItemViewModel(p.Color, p.Label));

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
