using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Persistence.Data
{
    public class DataContext : IDataContext
    {
        public DataContext()
        {
            DataRows = new List<DataRow>();

            // TODO: Remove this fake data
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(new DataColumn[] { new DataColumn(), new DataColumn() });
            var dataRow = dataTable.Rows.Add(0, 0);
            DataRows.Add(dataRow);
        }

        public List<DataRow> DataRows { get; set; }
    }
}
