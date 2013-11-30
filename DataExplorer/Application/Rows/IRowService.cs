using System.Collections.Generic;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Application.Rows
{
    public interface IRowService
    {
        IEnumerable<Row> GetAll();
        
        void SetSelectedRows(IEnumerable<Row> rows);

        IEnumerable<Row> GetSelectedRows();

        Row GetSelectedRow();
    }
}