using System.Windows;

namespace DataExplorer.Presentation.Views.ScatterPlots.Scalers
{
    public interface IScaleComputer
    {
        double ComputeScale(Size controlSize, Rect viewExtent);
    }
}