using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers.CsvFile.Events;
using DataExplorer.Application.ScatterPlots.Events;
using DataExplorer.Application.ScatterPlots.Layouts.Commands;
using DataExplorer.Application.ScatterPlots.Layouts.Queries;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;

namespace DataExplorer.Application.ScatterPlots
{
    public class ScatterPlotLayoutService : 
        IScatterPlotLayoutService, 
        IDomainHandler<ProjectOpenedEvent>,
        IDomainHandler<ProjectClosedEvent>,
        IAppHandler<CsvFileImportedEvent>
    {
        private readonly IGetXColumnQuery _getXColumnQuery;
        private readonly ISetXColumnCommand _setXColumnCommand;
        private readonly IGetYColumnQuery _getYColumnQuery;
        private readonly ISetYColumnCommand _setYColumnCommand;
        private readonly IClearLayoutCommand _clearLayoutCommand;

        public ScatterPlotLayoutService(
            IGetXColumnQuery getXColumnQuery,
            ISetXColumnCommand setXColumnCommand,
            IGetYColumnQuery getYColumnQuery,
            ISetYColumnCommand setYColumnCommand,
            IClearLayoutCommand clearLayoutCommand)
        {
            _getXColumnQuery = getXColumnQuery;
            _setXColumnCommand = setXColumnCommand;
            _getYColumnQuery = getYColumnQuery;
            _setYColumnCommand = setYColumnCommand;
            _clearLayoutCommand = clearLayoutCommand;
        }

        public event ScatterPlotLayoutColumnsChangedEvent LayoutColumnsChangedEvent;

        public ColumnDto GetXColumn()
        {
            return _getXColumnQuery.Query();
        }

        public void SetXColumn(ColumnDto columnDto)
        {
            _setXColumnCommand.Execute(columnDto);
        }

        public ColumnDto GetYColumn()
        {
            return _getYColumnQuery.Query();
        }

        public void SetYColumn(ColumnDto columnDto)
        {
            _setYColumnCommand.Execute(columnDto);
        }

        public void ClearLayout()
        {
            _clearLayoutCommand.Execute();
        }

        public void Handle(ProjectOpenedEvent args)
        {
            if (LayoutColumnsChangedEvent != null)
                LayoutColumnsChangedEvent(this, EventArgs.Empty);
        }

        public void Handle(ProjectClosedEvent args)
        {
            if (LayoutColumnsChangedEvent != null)
                LayoutColumnsChangedEvent(this, EventArgs.Empty);
        }

        public void Handle(CsvFileImportedEvent args)
        {
            if (LayoutColumnsChangedEvent != null)
                LayoutColumnsChangedEvent(this, EventArgs.Empty);
        }
    }
}
