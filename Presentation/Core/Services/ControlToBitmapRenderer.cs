using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DataExplorer.Presentation.Core.Services
{
    public class ControlToBitmapRenderer : IControlToBitmapRenderer
    {
        public BitmapSource Render(FrameworkElement control)
        {
            var width = (int) Math.Round(control.ActualWidth);

            var height = (int) Math.Round(control.ActualHeight);

            var bitmap = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Default);

            bitmap.Render(control);

            return bitmap;
        }
    }
}
