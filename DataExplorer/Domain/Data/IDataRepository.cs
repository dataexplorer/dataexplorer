using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Data
{
    public interface IDataRepository
    {
        List<DataRow> GetAll();
    }
}
