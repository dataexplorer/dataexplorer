using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Rows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Queries
{
    public class GetSelectedItemsQuery : IGetSelectedItemsQuery
    {
        private readonly IRowService _rowService;

        public GetSelectedItemsQuery(
            IRowService rowService)
        {
            _rowService = rowService;
        }

        public IEnumerable<CanvasItem> Execute(IEnumerable<CanvasItem> items)
        {
            var rows = _rowService.GetSelectedRows();

            var selectedItems = items
                .Where(p => rows.Any(q => q.Id == p.Id));

            return selectedItems;
        }
    }
}
