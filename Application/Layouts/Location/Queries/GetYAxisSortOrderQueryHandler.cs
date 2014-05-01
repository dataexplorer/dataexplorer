using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Layouts.Base.Queries;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Layouts;

namespace DataExplorer.Application.Layouts.Location.Queries
{
    public class GetYAxisSortOrderQueryHandler
         : BaseGetLayoutSortOrderQueryHandler,
         IQueryHandler<GetYAxisSortOrderQuery, SortOrder>
    {
        public GetYAxisSortOrderQueryHandler(IViewRepository repository)
            : base(repository)
        {
        }

        public SortOrder Execute(GetYAxisSortOrderQuery query)
        {
            return base.Execute(p => p.YAxisSortOrder);
        }
    }
}
