using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Filters;
using DataExplorer.Application.Filters.Events;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.ScatterPlots.Commands;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Application.ScatterPlots
{
    public class ScatterPlotEventsService 
        : IDomainHandler<ProjectOpenedEvent>,
        IDomainHandler<ProjectClosedEvent>,
        IDomainHandler<ScatterPlotLayoutChangedEvent>,
        IAppHandler<CsvFileImportedEvent>,
        IAppHandler<FilterChangedEvent>
    {
        private readonly IUpdatePlotsCommand _updateCommand;

        public ScatterPlotEventsService(IUpdatePlotsCommand updateCommand)
        {
            _updateCommand = updateCommand;
        }

        public void Handle(ProjectOpenedEvent args)
        {
            _updateCommand.UpdatePlots();
        }

        public void Handle(ProjectClosedEvent args)
        {
            _updateCommand.UpdatePlots();
        }

        public void Handle(ScatterPlotLayoutChangedEvent args)
        {
            _updateCommand.UpdatePlots();
        }

        public void Handle(CsvFileImportedEvent args)
        {
            _updateCommand.UpdatePlots();
        }

        public void Handle(FilterChangedEvent args)
        {
            _updateCommand.UpdatePlots();
        }
    }
}
