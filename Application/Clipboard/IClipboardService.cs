using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Clipboard
{
    public interface IClipboardService
    {
        bool CanCopy();

        void Copy();
        
        void CopyImage();
    }
}
