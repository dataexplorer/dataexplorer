using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Domain.Events;

namespace DataExplorer.Domain.ScatterPlots
{
    public class ScatterPlot : IScatterPlot
    {
        private Rect _viewExtent;
        private List<Plot> _plots;
        private readonly ScatterPlotLayout _layout;

        public ScatterPlot()
        {
            _viewExtent = new Rect(-0.1, -0.1, 1.2, 1.2);
            _plots = new List<Plot>();
            _layout = new ScatterPlotLayout();
        }

        public ScatterPlot(Rect viewExtent, List<Plot> plots, ScatterPlotLayout layout)
        {
            _viewExtent = viewExtent;
            _plots = plots;
            _layout = layout;
        }

        public Rect GetViewExtent()
        {
            return _viewExtent;
        }

        public void SetViewExtent(Rect viewExtent)
        {
            _viewExtent = viewExtent;

            DomainEvents.Raise(new ScatterPlotChangedEvent());
        }

        public List<Plot> GetPlots()
        {
            return _plots;
        }

        public ScatterPlotLayout GetLayout()
        {
            return _layout;
        }

        public void SetPlots(List<Plot> plots)
        {
            _plots = plots;

            DomainEvents.Raise(new ScatterPlotChangedEvent());
        }
    }
}
