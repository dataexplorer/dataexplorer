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
        ColumnDto GetXColumn();

        void SetXColumn(ColumnDto columnDto);
        
        ColumnDto GetYColumn();
        
        void SetYColumn(ColumnDto columnDto);
        
        void ClearLayout();
    }
}
