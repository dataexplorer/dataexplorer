using System.Windows.Media.Imaging;

namespace DataExplorer.Application.Clipboard.Commands
{
    public interface ICanvasToBitmapExporter
    {
        BitmapSource Export();
    }
}