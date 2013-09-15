using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using DataExplorer.Presentation.Core.Canvas;

namespace DataExplorer.Presentation.Core
{
    public interface IVisualService
    {
        void SetSource(CanvasControl source);
        int GetVisualsCount();
        Visual GetVisual(int index);
        void Add(List<Visual> visuals);
        void Clear();
    }
}
