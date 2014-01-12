using DataExplorer.Application.Columns;

namespace DataExplorer.Application.Views.ScatterPlots.Layouts.Commands
{
    public interface ISetXColumnCommand
    {
        void Execute(ColumnDto columnDto);
    }
}