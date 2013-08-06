using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.ScatterPlot;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Geometry;

namespace DataExplorer.Presentation.Views.ScatterPlot
{
    public class ScatterPlotViewModel : BaseViewModel, IScatterPlotViewModel
    {
        private readonly IScatterPlotService _scatterPlotService;
        private readonly IScatterPlotViewRenderer _renderer;
        private Size _controlSize;

        public Size ControlSize
        {
            set { SetControlSize(value); }
        }

        public List<Circle> Plots
        {
            get { return GetPlots(); }
        }

        public ScatterPlotViewModel(
            IScatterPlotService scatterPlotService, 
            IScatterPlotViewRenderer renderer)
        {
            _scatterPlotService = scatterPlotService;
            _renderer = renderer;
        }
        
        private List<Circle> GetPlots()
        {
            var viewExtent = _scatterPlotService.GetViewExtent();

            var plots = _scatterPlotService.GetPlots();

            var circles = _renderer.RenderPlots(_controlSize, viewExtent, plots);

            return circles;
        }

        private void SetControlSize(Size controlSize)
        {
            _controlSize = controlSize;

            var viewExtent = _scatterPlotService.GetViewExtent();

            var newViewExtent = _renderer.ResizeView(controlSize, viewExtent);

            _scatterPlotService.SetViewExtent(newViewExtent);

            OnPropertyChanged(() => Plots);
        }
    }
}
