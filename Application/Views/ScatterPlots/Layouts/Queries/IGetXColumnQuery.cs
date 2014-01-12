using DataExplorer.Application.Columns;

namespace DataExplorer.Application.Views.ScatterPlots.Layouts.Queries
{
    public interface IGetXColumnQuery
    {
        ColumnDto Query();
    }
}