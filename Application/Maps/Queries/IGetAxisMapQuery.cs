using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Domain.Maps;

namespace DataExplorer.Application.Maps.Queries
{
    public interface IGetAxisMapQuery
    {
        IAxisMap Execute(ColumnDto columnDto, double targetMin, double targetMax);
    }
}
