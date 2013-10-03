using DataExplorer.Application.Columns;

namespace DataExplorer.Application.ScatterPlots.Layouts.Commands
{
    public interface ISetYColumnCommand
    {
        void Execute(ColumnDto columnDto);
    }
}