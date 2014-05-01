using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Layouts.Base.Queries;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Layouts;

namespace DataExplorer.Application.Layouts.Size.Queries
{
    public class GetSizeSortOrderQueryHandler 
        : BaseGetLayoutSortOrderQueryHandler,
        IQueryHandler<GetSizeSortOrderQuery, SortOrder>
    {
        public GetSizeSortOrderQueryHandler(IViewRepository repository)
            : base(repository)
        {
        }

        public SortOrder Execute(GetSizeSortOrderQuery query)
        {
            return base.Execute(p => p.SizeSortOrder);
        }
    }
}
