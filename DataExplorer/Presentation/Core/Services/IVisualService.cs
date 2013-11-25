using System.Collections.Generic;
using System.Windows.Media;
using DataExplorer.Presentation.Core.Canvas;

namespace DataExplorer.Presentation.Core.Services
{
    public interface IVisualService
    {
        void SetSource(CanvasControl source);
        int GetVisualsCount();
        Visual GetVisual(int index);
        void Add(IEnumerable<Visual> visuals);
        void Clear();
    }
}
