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
using DataExplorer.Presentation.Views.ScatterPlots.Renderers;

namespace DataExplorer.Presentation.Views.ScatterPlots
{
    public class ScatterPlotViewModel 
        : BaseViewModel, 
        IScatterPlotViewModel,
        IDomainHandler<ScatterPlotChangedEvent>
    {
        private readonly IScatterPlotContextMenuViewModel _contextMenuViewModel;
        private readonly IScatterPlotService _service;
        private readonly IScatterPlotLayoutService _layoutService;
        private readonly IScatterPlotViewRenderer _renderer;
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
            IScatterPlotService service,
            IScatterPlotLayoutService layoutService,
            IScatterPlotViewRenderer renderer, 
            IViewResizer resizer,
            IScatterPlotViewScaler scaler)
        {
            _contextMenuViewModel = contextMenuViewModel;
            _service = service;
            _layoutService = layoutService;
            _renderer = renderer;
            _scaler = scaler;
            _resizer = resizer;
        }

        private IEnumerable<ICanvasItem> GetItems()
        {
            var viewExtent = _service.GetViewExtent();

            var plots = _service.GetPlots();

            var canvasPlots = _renderer.RenderPlots(_controlSize, viewExtent, plots);

            foreach (var canvasPlot in canvasPlots)
                yield return canvasPlot;

            var xAxisColumn = _layoutService.GetXColumn();

            var xAxisLabelName = xAxisColumn != null
                ? xAxisColumn.Name
                : string.Empty;

            yield return _renderer.RenderXAxisLabel(_controlSize, xAxisLabelName);

            var yAxisColumn = _layoutService.GetYColumn();

            var yAxisLabelName = yAxisColumn != null
                ? yAxisColumn.Name
                : string.Empty;

            yield return _renderer.RenderYAxisLabel(_controlSize, yAxisLabelName);


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
