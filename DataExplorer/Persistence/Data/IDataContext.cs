using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Persistence.Data
{
    public interface IDataContext
    {
        List<DataRow> DataRows { get; set; }
    }
}
