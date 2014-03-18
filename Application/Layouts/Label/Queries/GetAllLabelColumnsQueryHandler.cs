using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Layouts.Base.Queries;
using DataExplorer.Application.Layouts.Label.Queries;

namespace DataExplorer.Application.Layouts.Label.Queries
{
    public class GetAllLabelColumnsQueryHandler
        : BaseGetAllLayoutColumnsQueryHandler,
        IQueryHandler<GetAllLabelColumnsQuery, List<ColumnDto>>
    {
        public GetAllLabelColumnsQueryHandler(
            IColumnRepository repository,
            IColumnAdapter adapter)
            : base(repository, adapter)
        {

        }

        public List<ColumnDto> Execute(GetAllLabelColumnsQuery query)
        {
            return Execute(p => p.DataType != typeof(BitmapImage));
        }
    }
}
