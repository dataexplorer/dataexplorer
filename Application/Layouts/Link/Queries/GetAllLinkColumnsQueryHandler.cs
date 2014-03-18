using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Layouts.Base.Queries;
using DataExplorer.Application.Layouts.Link.Queries;
using DataExplorer.Domain.Semantics;

namespace DataExplorer.Application.Layouts.Link.Queries
{
    public class GetAllLinkColumnsQueryHandler
         : BaseGetAllLayoutColumnsQueryHandler,
         IQueryHandler<GetAllLinkColumnsQuery, List<ColumnDto>>
    {
        public GetAllLinkColumnsQueryHandler(
            IColumnRepository repository,
            IColumnAdapter adapter)
            : base(repository, adapter)
        {

        }

        public List<ColumnDto> Execute(GetAllLinkColumnsQuery query)
        {
            return Execute(p => p.SemanticType == SemanticType.Uri);
        }
    }
}
