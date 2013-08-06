using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataExplorer.Domain.ScatterPlot
{
    public class ScatterPlot : IScatterPlot
    {
        private Rect _viewExtent;
        private List<Plot> _plots;

        public ScatterPlot()
        {
            _viewExtent = new Rect(-100, -100, 1200, 1200);
            _plots = new List<Plot>();
        }

        public Rect GetViewExtent()
        {
            return _viewExtent;
        }

        public void SetViewExtent(Rect viewExtent)
        {
            _viewExtent = viewExtent;
        }

        public void SetPlots(List<Plot> plots)
        {
            _plots = plots;
        }

        public List<Plot> GetPlots()
        {
            return _plots;
        }
    }
}
