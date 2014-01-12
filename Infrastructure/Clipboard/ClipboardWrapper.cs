using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using DataExplorer.Application;

namespace DataExplorer.Infrastructure.Clipboard
{
    public class ClipboardWrapper : IClipboard
    {
        public void SetText(string text)
        {
            System.Windows.Clipboard.SetText(text);
        }

        public void SetImage(BitmapSource image)
        {
            System.Windows.Clipboard.SetImage(image);
        }
    }
}
