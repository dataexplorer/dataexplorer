using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Events;

namespace DataExplorer.Application.Application.Events
{
    public class PaneVisibilityChangedEvent : IEvent
    {
        private readonly Pane _pane;
        private readonly bool _isVisible;

        public PaneVisibilityChangedEvent(Pane pane, bool isVisible)
        {
            _pane = pane;
            _isVisible = isVisible;
        }

        public Pane Pane
        {
            get { return _pane; }
        }

        public bool IsVisible
        {
            get { return _isVisible; }
        }
    }
}
