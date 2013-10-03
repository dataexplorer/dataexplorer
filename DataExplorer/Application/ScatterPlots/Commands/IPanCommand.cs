using System.Windows;

namespace DataExplorer.Application.ScatterPlots.Tasks
{
    public interface IPanCommand
    {
        void Pan(Vector vector);
    }
}