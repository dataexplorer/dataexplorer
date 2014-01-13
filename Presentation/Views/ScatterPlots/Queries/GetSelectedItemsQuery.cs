using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Rows;
using DataExplorer.Application.Rows.Queries;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Queries
{
    public class GetSelectedItemsQuery : IGetSelectedItemsQuery
    {
        private readonly IQueryBus _queryBus;

        public GetSelectedItemsQuery(
            IQueryBus queryBus)
        {
            _queryBus = queryBus;
        }

        public IEnumerable<CanvasItem> Execute(IEnumerable<CanvasItem> items)
        {
            var rows = _queryBus.Execute(new GetSelectedRowsQuery());

            var selectedItems = items
                .Where(p => rows.Any(q => q.Id == p.Id));

            return selectedItems;
        }
    }
}
