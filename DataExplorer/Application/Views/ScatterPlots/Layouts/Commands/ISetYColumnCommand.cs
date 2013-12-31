using DataExplorer.Application.Columns;

namespace DataExplorer.Application.Views.ScatterPlots.Layouts.Commands
{
    public interface ISetYColumnCommand
    {
        void Execute(ColumnDto columnDto);
    }
}