using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Layouts.Base.Queries;

namespace DataExplorer.Application.Layouts.Shape.Queries
{
    public class GetAllShapeColumnsQueryHandler 
        : BaseGetAllLayoutColumnsQueryHandler,
        IQueryHandler<GetAllShapeColumnsQuery, List<ColumnDto>>
    {
        public GetAllShapeColumnsQueryHandler(
            IColumnRepository repository,
            IColumnAdapter adapter) 
            : base(repository, adapter)
        {

        }

        public List<ColumnDto> Execute(GetAllShapeColumnsQuery query)
        {
            return Execute(p => p.DataType == typeof(BitmapImage));
        }
    }
}
