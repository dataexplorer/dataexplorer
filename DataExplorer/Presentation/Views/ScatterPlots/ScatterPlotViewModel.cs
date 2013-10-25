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
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.Renderers;

namespace DataExplorer.Presentation.Views.ScatterPlots
{
    public class ScatterPlotViewModel 
        : BaseViewModel, 
        IScatterPlotViewModel,
        IDomainHandler<ScatterPlotChangedEvent>
    {
        private readonly IScatterPlotContextMenuViewModel _contextMenuViewModel;
        private readonly IGetScatterPlotItemsQuery _getItemsQuery;
        private readonly IScatterPlotService _service;
        private readonly IViewResizer _resizer;
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

        public List<ICanvasItem> Items
        {
            get { return GetItems().ToList(); }
        }
        
        public ScatterPlotViewModel(
            IScatterPlotContextMenuViewModel contextMenuViewModel,
            IGetScatterPlotItemsQuery getItemsQuery,
            IScatterPlotService service,
            IViewResizer resizer,
            IScatterPlotViewScaler scaler)
        {
            _contextMenuViewModel = contextMenuViewModel;
            _getItemsQuery = getItemsQuery;
            _service = service;
            _scaler = scaler;
            _resizer = resizer;
        }

        private IEnumerable<ICanvasItem> GetItems()
        {
            return _getItemsQuery.Execute(_controlSize);
        }

        private void SetControlSize(Size controlSize)
        {
            _controlSize = controlSize;

            var viewExtent = _service.GetViewExtent();

            var newViewExtent = _resizer.ResizeView(controlSize, viewExtent);

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
            OnPropertyChanged(() => Items);
        }
    }
}
