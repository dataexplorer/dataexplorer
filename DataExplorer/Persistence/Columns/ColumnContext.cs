using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Persistence.Columns
{
    public class ColumnContext : IColumnContext
    {
        public ColumnContext()
        {
            Columns = new List<Column>();
        }

        public List<Column> Columns { get; set; }
    }
}
