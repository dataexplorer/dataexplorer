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
        private readonly IGetDistinctColumnValuesQuery _getValuesQuery;

        public ColumnService(
            IGetAllColumnsQuery getAllColumnsQuery,
            IGetDistinctColumnValuesQuery getValuesQuery)
        {
            _getAllColumnsQuery = getAllColumnsQuery;
            _getValuesQuery = getValuesQuery;
        }

        public List<ColumnDto> GetAllColumns()
        {
            return _getAllColumnsQuery.Query();
        }

        public IEnumerable<object> GetDistinctColumnValues(int columnId)
        {
            return _getValuesQuery.Execute(columnId);
        }
    }
}
