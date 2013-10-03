using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Commands;
using DataExplorer.Presentation.Core.Geometry;

namespace DataExplorer.Presentation.Views.ScatterPlots
{
    public class ScatterPlotViewModel 
        : BaseViewModel, 
        IScatterPlotViewModel,
        IDomainHandler<ScatterPlotChangedEvent>
    {
        private readonly IScatterPlotContextMenuViewModel _contextMenuViewModel;
        private readonly IScatterPlotService _service;
        private readonly IScatterPlotViewRenderer _renderer;
        private readonly IScatterPlotViewScaler _scaler;
        private Size _controlSize;

        public IScatterPlotContextMenuViewModel ContextMenuViewModel
        {
            get { return _contextMenuViewModel; }
        }

        public Size ControlSize
        {
            set { SetControlSize(value); }
        }

        public List<Circle> Plots
        {
            get { return GetPlots(); }
        }
        
        public ScatterPlotViewModel(
            IScatterPlotContextMenuViewModel contextMenuViewModel,
            IScatterPlotService service, 
            IScatterPlotViewRenderer renderer, 
            IScatterPlotViewScaler scaler)
        {
            _contextMenuViewModel = contextMenuViewModel;
            _service = service;
            _renderer = renderer;
            _scaler = scaler;
        }

        private List<Circle> GetPlots()
        {
            var viewExtent = _service.GetViewExtent();

            var plots = _service.GetPlots();

            var circles = _renderer.RenderPlots(_controlSize, viewExtent, plots);

            return circles;
        }

        private void SetControlSize(Size controlSize)
        {
            _controlSize = controlSize;

            var viewExtent = _service.GetViewExtent();

            var newViewExtent = _renderer.ResizeView(controlSize, viewExtent);

            _service.SetViewExtent(newViewExtent);
        }

        public void HandleZoomIn(Point center)
        {
            var viewExtent = _service.GetViewExtent();

            var scaledCenter = _scaler.ScalePoint(center, _controlSize, viewExtent);

            _service.ZoomIn(scaledCenter);
        }

        public void HandleZoomOut(Point center)
        {
            var viewExtent = _service.GetViewExtent();

            var scaledCenter = _scaler.ScalePoint(center, _controlSize, viewExtent);

            _service.ZoomOut(scaledCenter);
        }

        public void HandlePan(Vector vector)
        {
            var viewExtent = _service.GetViewExtent();

            var scaledVector = _scaler.ScaleVector(vector, _controlSize, viewExtent);

            _service.Pan(scaledVector);
        }

        public void Handle(ScatterPlotChangedEvent args)
        {
            OnPropertyChanged(() => Plots);
        }
    }
}
