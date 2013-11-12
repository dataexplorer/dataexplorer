using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Columns
{
    public interface IColumnService
    {
        List<ColumnDto> GetAllColumns();

        IEnumerable<object> GetDistinctColumnValues(int columnId);
    }
}
