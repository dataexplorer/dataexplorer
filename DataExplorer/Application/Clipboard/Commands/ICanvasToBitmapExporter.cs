using System.Windows.Media.Imaging;
using DataExplorer.Presentation.Core.Canvas;

namespace DataExplorer.Application.Clipboard.Commands
{
    public interface ICanvasToBitmapExporter
    {
        BitmapSource Export();
    }
}