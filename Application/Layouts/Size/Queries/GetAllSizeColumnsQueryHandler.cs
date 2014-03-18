using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Layouts.Base.Queries;

namespace DataExplorer.Application.Layouts.Size.Queries
{
    public class GetAllSizeColumnsQueryHandler
        : BaseGetAllLayoutColumnsQueryHandler,
        IQueryHandler<GetAllSizeColumnsQuery, List<ColumnDto>>
    {
        public GetAllSizeColumnsQueryHandler(
            IColumnRepository repository,
            IColumnAdapter adapter)
            : base(repository, adapter)
        {

        }

        public List<ColumnDto> Execute(GetAllSizeColumnsQuery query)
        {
            return Execute(p => p.DataType != typeof(BitmapImage));
        }
    }
}
