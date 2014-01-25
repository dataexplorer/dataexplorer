using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Domain.Tests.Views.ScatterPlots
{
    public class ScatterPlotBuilder
    {
        private ScatterPlotLayout _layout;
        private Rect _viewExtent;
        private List<Plot> _plots; 

        public ScatterPlotBuilder()
        {
            _layout = new ScatterPlotLayout();
            _viewExtent = new Rect();
            _plots = new List<Plot>();
        }

        public ScatterPlotBuilder WithLayout(ScatterPlotLayout layout)
        {
            _layout = layout;
            return this;
        }

        public ScatterPlot Build()
        {
            return new ScatterPlot(_layout, _viewExtent, _plots);    
        }
    }
}
