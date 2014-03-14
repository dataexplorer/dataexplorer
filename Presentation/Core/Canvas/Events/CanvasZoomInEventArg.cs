using System;
using System.Windows;

namespace DataExplorer.Presentation.Core.Canvas.Events
{
    public class CanvasZoomInEventArg : EventArgs
    {
        private readonly Point _center;
        
        public CanvasZoomInEventArg(Point center)
        {
            _center = center;
        }

        public Point Center
        {
            get { return _center; }
        }
    }
}