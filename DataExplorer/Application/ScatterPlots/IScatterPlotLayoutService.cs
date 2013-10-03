using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.ScatterPlots.Events;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Application.ScatterPlots
{
    public interface IScatterPlotLayoutService
    {
        event ScatterPlotLayoutColumnsChangedEvent LayoutColumnsChangedEvent;
        ColumnDto GetXColumn();
        void SetXColumn(ColumnDto columnDto);
        ColumnDto GetYColumn();
        void SetYColumn(ColumnDto columnDto);
        void ClearLayout();
    }
}
