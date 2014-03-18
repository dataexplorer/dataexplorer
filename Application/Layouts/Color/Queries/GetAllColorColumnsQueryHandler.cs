using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Layouts.Base.Queries;

namespace DataExplorer.Application.Layouts.Color.Queries
{
    public class GetAllColorColumnsQueryHandler
        : BaseGetAllLayoutColumnsQueryHandler,
        IQueryHandler<GetAllColorColumnsQuery, List<ColumnDto>>
    {
        public GetAllColorColumnsQueryHandler(
            IColumnRepository repository,
            IColumnAdapter adapter)
            : base(repository, adapter)
        {

        }

        public List<ColumnDto> Execute(GetAllColorColumnsQuery query)
        {
            return Execute(p => p.DataType != typeof(BitmapImage));
        }
    }
}
