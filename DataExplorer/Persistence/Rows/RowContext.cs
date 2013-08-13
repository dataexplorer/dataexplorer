using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Persistence.Rows
{
    public class RowContext : IRowContext
    {
        public RowContext()
        {
            Rows = new List<Row>();

            // TODO: Remove this fake data
            var fields = new List<object> { 1, 2, 3 };
            var row = new Row(fields);
            Rows.Add(row);
        }

        public List<Row> Rows { get; set; }
    }
}
