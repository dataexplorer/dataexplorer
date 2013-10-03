using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns.Queries;

namespace DataExplorer.Application.Columns
{
    public class ColumnService : IColumnService
    {
        private readonly IGetAllColumnsQuery _getAllColumnsQuery;

        public ColumnService(IGetAllColumnsQuery getAllColumnsQuery)
        {
            _getAllColumnsQuery = getAllColumnsQuery;
        }

        public List<ColumnDto> GetAllColumns()
        {
            return _getAllColumnsQuery.Query();
        }
    }
}
