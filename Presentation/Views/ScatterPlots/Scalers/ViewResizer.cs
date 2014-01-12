using System.Windows;

namespace DataExplorer.Presentation.Views.ScatterPlots.Scalers
{
    public class ViewResizer : IViewResizer
    {
        public Rect ResizeView(Size controlSize, Rect viewExtent)
        {
            var aspectRatio = controlSize.Width / controlSize.Height;

            var width = (aspectRatio > 1)
                ? viewExtent.Height * aspectRatio
                : viewExtent.Width;

            var height = (aspectRatio < 1)
                ? viewExtent.Width * (1 / aspectRatio)
                : viewExtent.Height;

            var left = viewExtent.Left - (width - viewExtent.Width) / 2;

            var top = viewExtent.Top - (height - viewExtent.Height) / 2;

            return new Rect(left, top, width, height);
        }
    }
}
