using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Events;
using DataExplorer.Application.Filters;
using DataExplorer.Application.Importers.CsvFile.Events;
using DataExplorer.Application.ScatterPlots.Tasks;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Application.ScatterPlots
{
    public class ScatterPlotEventsService : 
        IDomainHandler<ProjectOpenedEvent>,
        IDomainHandler<ProjectClosedEvent>,
        IDomainHandler<ScatterPlotLayoutChangedEvent>,
        IAppHandler<CsvFileImportedEvent>,
        IAppHandler<FilterChangedEvent>
    {
        private readonly IUpdatePlotsTask _updateTask;
        
        public ScatterPlotEventsService(IUpdatePlotsTask updateTask)
        {
            _updateTask = updateTask;
        }

        public void Handle(ProjectOpenedEvent args)
        {
            _updateTask.UpdatePlots();
        }

        public void Handle(ProjectClosedEvent args)
        {
            _updateTask.UpdatePlots();
        }

        public void Handle(ScatterPlotLayoutChangedEvent args)
        {
            _updateTask.UpdatePlots();
        }

        public void Handle(CsvFileImportedEvent args)
        {
            _updateTask.UpdatePlots();
        }

        public void Handle(FilterChangedEvent args)
        {
            _updateTask.UpdatePlots();
        }
    }
}
