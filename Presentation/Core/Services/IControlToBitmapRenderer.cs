using System.Windows;
using System.Windows.Media.Imaging;

namespace DataExplorer.Presentation.Core.Services
{
    public interface IControlToBitmapRenderer
    {
        BitmapSource Render(FrameworkElement control);
    }
}
