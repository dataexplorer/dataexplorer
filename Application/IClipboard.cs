using System.Windows.Media.Imaging;

namespace DataExplorer.Application
{
    public interface IClipboard
    {
        void SetText(string text);

        void SetImage(BitmapSource image);
    }
}
