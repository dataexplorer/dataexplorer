using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Persistence.Rows
{
    public interface IRowContext
    {
        List<Row> Rows { get; set; }
    }
}
