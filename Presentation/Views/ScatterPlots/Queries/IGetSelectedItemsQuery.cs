using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Queries
{
    public interface IGetSelectedItemsQuery
    {
        IEnumerable<CanvasItem> Execute(IEnumerable<CanvasItem> items);
    }
}
