using System.Windows.Media.Imaging;
using DataExplorer.Application.Clipboard.Commands;
using DataExplorer.Presentation.Core.Canvas;

namespace DataExplorer.Presentation.Core.Services
{
    public class CanvasToBitmapExporter : ICanvasToBitmapExporter
    {
        private readonly IWindowService _windowService;
        private readonly IControlFinder _finder;
        private readonly IControlToBitmapRenderer _renderer;

        public CanvasToBitmapExporter(
            IWindowService windowService,
            IControlFinder finder, 
            IControlToBitmapRenderer renderer)
        {
            _windowService = windowService;
            _finder = finder;
            _renderer = renderer;
        }

        public BitmapSource Export()
        {
            var mainWindow = _windowService.GetMainWindow();

            var canvas = _finder.Find<CanvasControl>(mainWindow);

            var image = _renderer.Render(canvas);

            return image;
        }
    }
}
