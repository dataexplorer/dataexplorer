using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Infrastructure.Clipboard;

namespace DataExplorer.Application.Clipboard.Commands
{
    public class CopyImageToClipboardCommand : ICopyImageToClipboardCommand
    {
        private readonly ICanvasToBitmapExporter _exporter;
        private readonly IClipboard _clipboard;

        public CopyImageToClipboardCommand(
            ICanvasToBitmapExporter exporter, 
            IClipboard clipboard)
        {
            _exporter = exporter;
            _clipboard = clipboard;
        }

        public void Execute()
        {
            var image = _exporter.Export();

            _clipboard.SetImage(image);
        }
    }
}
