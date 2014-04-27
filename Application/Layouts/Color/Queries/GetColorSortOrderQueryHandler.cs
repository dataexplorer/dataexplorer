using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Layouts.Base.Queries;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Layouts;

namespace DataExplorer.Application.Layouts.Color.Queries
{
    public class GetColorSortOrderQueryHandler
        : BaseGetLayoutSortOrderQueryHandler,
        IQueryHandler<GetColorSortOrderQuery, SortOrder>
    {
        public GetColorSortOrderQueryHandler(IViewRepository repository)
            : base(repository)
        {
        }

        public SortOrder Execute(GetColorSortOrderQuery query)
        {
            return base.Execute(p => p.ColorSortOrder);
        }
    }
}
