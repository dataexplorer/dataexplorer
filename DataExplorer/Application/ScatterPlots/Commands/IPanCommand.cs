using System.Windows;

namespace DataExplorer.Application.ScatterPlots.Commands
{
    public interface IPanCommand
    {
        void Pan(Vector vector);
    }
}