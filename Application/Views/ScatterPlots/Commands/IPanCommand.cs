using System.Windows;

namespace DataExplorer.Application.Views.ScatterPlots.Commands
{
    public interface IPanCommand
    {
        void Pan(Vector vector);
    }
}