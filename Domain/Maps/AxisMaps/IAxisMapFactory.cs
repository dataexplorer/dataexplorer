using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Layouts;

namespace DataExplorer.Domain.Maps.AxisMaps
{
    public interface IAxisMapFactory
    {
        AxisMap Create(Column column, double targetMin, double targetMax, SortOrder sortOrder);
    }
}
