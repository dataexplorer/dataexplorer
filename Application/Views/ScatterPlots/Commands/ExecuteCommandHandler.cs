using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Rows;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Commands
{
    public class ExecuteCommandHandler : ICommandHandler<ExecuteCommand>
    {
        private readonly IViewRepository _viewRepository;
        private readonly IRowRepository _rowRepository;
        private readonly IProcess _process;

        public ExecuteCommandHandler(
            IViewRepository viewRepository, 
            IRowRepository rowRepository, 
            IProcess process)
        {
            _rowRepository = rowRepository;
            _process = process;
            _viewRepository = viewRepository;
        }

        public void Execute(ExecuteCommand command)
        {
            var view = _viewRepository.Get<ScatterPlot>();

            var layout = view.GetLayout();

            var linkColumn = layout.LinkColumn;

            if (linkColumn == null)
                return;

            var row = _rowRepository.Get(command.Id);

            var link = (string) row[linkColumn.Index];

            _process.Start(link);
        }
    }
}
