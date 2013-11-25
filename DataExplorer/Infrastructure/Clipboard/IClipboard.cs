using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DataExplorer.Infrastructure.Clipboard
{
    public interface IClipboard
    {
        void SetText(string text);

        void SetImage(BitmapSource image);
    }
}
