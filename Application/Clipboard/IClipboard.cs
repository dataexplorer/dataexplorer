using System.Windows.Media.Imaging;

namespace DataExplorer.Application.Clipboard
{
    public interface IClipboard
    {
        void SetText(string text);

        void SetImage(BitmapSource image);
    }
}
