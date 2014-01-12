using System.Windows;
using System.Windows.Media;
using DataExplorer.Presentation.Core.Canvas;
using DataExplorer.Presentation.Core.Services;

namespace DataExplorer.Presentation.Tests.Core.Canvas
{
    public class CanvasControlHarness : CanvasControl
    {
        public CanvasControlHarness(
            IDependencyPropertyService propertyService,
            ICanvasRenderer renderer,
            IVisualService visualService)
            : base(propertyService, renderer, visualService)
        {
        }

        public int GetVisualChildrenCount()
        {
            return VisualChildrenCount;
        }

        public new Visual GetVisualChild(int index)
        {
            return base.GetVisualChild(index);
        }

        public new void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
        }
    }
}
