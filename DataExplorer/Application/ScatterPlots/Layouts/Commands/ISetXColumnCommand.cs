using DataExplorer.Application.Columns;

namespace DataExplorer.Application.ScatterPlots.Layouts.Commands
{
    public interface ISetXColumnCommand
    {
        void Execute(ColumnDto columnDto);
    }
}