

using System.Windows;

namespace DataExplorer.Presentation.Core.Canvas.Events
{
    public class CanvasPanEventArgs
    {
        private readonly Vector _delta;
        
        public CanvasPanEventArgs(Vector delta)
        {
            _delta = delta;
        }

        public Vector Delta
        {
            get { return _delta; }
        }
    }
}