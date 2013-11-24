using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Infrastructure.Clipboard
{
    public class ClipboardWrapper : IClipboard
    {
        public void SetText(string text)
        {
            System.Windows.Clipboard.SetText(text);
        }
    }
}
