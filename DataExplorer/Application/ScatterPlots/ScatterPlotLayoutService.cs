using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;
using DataExplorer.Persistence.Columns;

namespace DataExplorer.Application.ScatterPlots
{
    public class ScatterPlotLayoutService : 
        IScatterPlotLayoutService, 
        IHandler<ProjectOpenedEvent>
    {
        private readonly IViewRepository _viewRepository;
        private readonly IColumnRepository _columnRepository;
        private readonly IColumnAdapter _columnAdapter;

        public ScatterPlotLayoutService(
            IViewRepository viewRepository, 
            IColumnRepository columnRepository,
            IColumnAdapter columnAdapter)
        {
            _viewRepository = viewRepository;
            _columnRepository = columnRepository;
            _columnAdapter = columnAdapter;
        }

        public event ScatterPlotLayoutColumnsChangedEvent LayoutColumnsChangedEvent;

        public List<ColumnDto> GetColumns()
        {
            var columns = _columnRepository.GetAll();

            var columnDtos = columns
                .Select(p => _columnAdapter.Adapt(p))
                .ToList();

            return columnDtos;
        }

        public ColumnDto GetXColumn()
        {
            var scatterPlot = _viewRepository.GetScatterPlot();

            var layout = scatterPlot.GetLayout();

            var column = layout.XAxisColumn;

            var columnDto = _columnAdapter.Adapt(column);

            return columnDto;
        }

        public void SetXColumn(ColumnDto columnDto)
        {
            var column = _columnRepository.Get(columnDto.Id);

            var scatterPlot = _viewRepository.GetScatterPlot();

            var layout = scatterPlot.GetLayout();

            layout.XAxisColumn = column;
        }

        public void Handle(ProjectOpenedEvent args)
        {
            if (LayoutColumnsChangedEvent != null)
                LayoutColumnsChangedEvent(this, EventArgs.Empty);
        }
    }
}
