using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Layouts.Base.Queries;

namespace DataExplorer.Application.Layouts.Location.Queries
{
    public class GetAllAxisColumnsQueryHandler
           : BaseGetAllLayoutColumnsQueryHandler,
           IQueryHandler<GetAllAxisColumnsQuery, List<ColumnDto>>
    {
        public GetAllAxisColumnsQueryHandler(
            IColumnRepository repository,
            IColumnAdapter adapter)
            : base(repository, adapter)
        {

        }

        public List<ColumnDto> Execute(GetAllAxisColumnsQuery query)
        {
            return Execute(p => p.DataType != typeof(BitmapImage));
        }
    }
}
