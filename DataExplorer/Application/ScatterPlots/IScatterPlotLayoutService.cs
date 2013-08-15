using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;

namespace DataExplorer.Application.ScatterPlots
{
    public interface IScatterPlotLayoutService
    {
        event ScatterPlotLayoutColumnsChangedEvent LayoutColumnsChangedEvent;
        List<ColumnDto> GetColumns();
        ColumnDto GetXColumn();
        void SetXColumn(ColumnDto columnDto);
    }
}
