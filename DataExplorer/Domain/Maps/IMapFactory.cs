using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.Maps
{
    public interface IMapFactory
    {
        IAxisMap CreateAxisMap(Column column, double targetMin, double targetMax);
    }
}
