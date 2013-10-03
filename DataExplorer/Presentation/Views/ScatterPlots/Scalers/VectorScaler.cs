using System.Windows;

namespace DataExplorer.Presentation.Views.ScatterPlots.Scalers
{
    public class VectorScaler : IVectorScaler
    {
        public Vector ScaleVector(Vector vector, Size controlSize, Rect viewExtent)
        {
            var scale = (controlSize.Width > controlSize.Height)
                ? controlSize.Width / viewExtent.Width
                : controlSize.Height / viewExtent.Height;

            var scaledX = vector.X / scale;

            var scaledY = (vector.Y * -1) / scale;

            var scaledVector = new Vector(scaledX, scaledY);

            return scaledVector;
        }
    }
}
