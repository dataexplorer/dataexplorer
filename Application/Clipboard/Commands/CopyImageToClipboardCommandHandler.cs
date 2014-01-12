using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Clipboard.Commands
{
    public class CopyImageToClipboardCommandHandler 
        : ICommandHandler<CopyImageToClipboardCommand>
    {
        private readonly ICanvasToBitmapExporter _exporter;
        private readonly IClipboard _clipboard;

        public CopyImageToClipboardCommandHandler(
            ICanvasToBitmapExporter exporter, 
            IClipboard clipboard)
        {
            _exporter = exporter;
            _clipboard = clipboard;
        }

        public void Execute(CopyImageToClipboardCommand command)
        {
            var image = _exporter.Export();

            _clipboard.SetImage(image);
        }
    }
}
