using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using DataExplorer.Presentation.Core.Canvas;

namespace DataExplorer.Presentation.Core.Services
{
    public class VisualService : IVisualService
    {
        private CanvasControl _source;
        private readonly List<Visual> _visuals;

        public VisualService()
        {
            _visuals = new List<Visual>();
        }

        // TODO: This method is for testing only, try to eliminate it
        public CanvasControl GetSource()
        {
            return _source;
        }

        public void SetSource(CanvasControl source)
        {
            _source = source;
        }
        
        public int GetVisualsCount()
        {
            return _visuals.Count();
        }

        public Visual GetVisual(int index)
        {
            return _visuals[index];
        }

        public void Add(IEnumerable<Visual> visuals)
        {
            _visuals.AddRange(visuals);

            foreach (var visual in _visuals)
                _source.AddChild(visual);
        }

        public void Clear()
        {
            foreach (var visual in _visuals)
                _source.RemoveChild(visual);

            _visuals.Clear();
        }
    }
}
