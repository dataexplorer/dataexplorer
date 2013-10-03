using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;

namespace DataExplorer.Application.ScatterPlots.Layouts.Commands
{
    public class SetXColumnCommand : ISetXColumnCommand
    {
        private readonly IColumnRepository _columnRepository;
        private readonly IViewRepository _viewRepository;

        public SetXColumnCommand(
            IColumnRepository columnRepository,
            IViewRepository viewRepository)
        {
            _columnRepository = columnRepository;
            _viewRepository = viewRepository;
        }

        public void Execute(ColumnDto columnDto)
        {
            var column = _columnRepository.Get(columnDto.Id);

            var scatterPlot = _viewRepository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            layout.XAxisColumn = column;
        }
    }
}
