using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Rows.Commands;
using DataExplorer.Application.Rows.Queries;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Commands
{
    public class SelectCommand : ISelectCommand
    {
        private readonly IMessageBus _commandBus;

        public SelectCommand(IMessageBus commandBus)
        {
            _commandBus = commandBus;
        }

        public void Execute(List<CanvasItem> items)
        {
            var rows = _commandBus.Execute(new GetAllRowsQuery());

            var selectedRows = items
                .Select(p => rows.First(q => q.Id == p.Id))
                .ToList();

            _commandBus.Execute(new SetSelectedRowsCommand(selectedRows));
        }
    }
}
