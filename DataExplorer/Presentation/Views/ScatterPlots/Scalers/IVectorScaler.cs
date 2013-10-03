using System.Windows;

namespace DataExplorer.Presentation.Views.ScatterPlots.Scalers
{
    public interface IVectorScaler
    {
        Vector ScaleVector(Vector vector, Size controlSize, Rect viewExtent);
    }
}
