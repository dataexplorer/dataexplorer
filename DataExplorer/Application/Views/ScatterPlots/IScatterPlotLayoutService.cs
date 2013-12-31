using DataExplorer.Application.Columns;

namespace DataExplorer.Application.Views.ScatterPlots
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
