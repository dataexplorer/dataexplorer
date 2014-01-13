using System.Windows.Media.Imaging;

namespace DataExplorer.Application.Clipboard
{
    public interface ICanvasToBitmapExporter
    {
        BitmapSource Export();
    }
}