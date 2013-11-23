using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Rows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Commands
{
    public class SelectCommand : ISelectCommand
    {
        private readonly IRowService _rowService;

        public SelectCommand(IRowService rowService)
        {
            _rowService = rowService;
        }

        public void Execute(List<CanvasItem> items)
        {
            var rows = _rowService.GetAll()
                .Where(p => items.Any(q => q.Id == p.Id));

            _rowService.SetSelectedRows(rows);
        }
    }
}
