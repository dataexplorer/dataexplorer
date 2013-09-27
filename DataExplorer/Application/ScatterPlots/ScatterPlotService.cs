using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.ScatterPlots.Tasks;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;

namespace DataExplorer.Application.ScatterPlots
{
    public class ScatterPlotService : IScatterPlotService
    {
        private readonly IGetViewExtentTask _getViewExtentTask;
        private readonly ISetViewExtentTask _setViewExtentTask;
        private readonly IGetPlotsTask _getPlotsTask;
        private readonly IZoomInTask _zoomInTask;
        private readonly IZoomOutTask _zoomOutTask;
        private readonly IPanTask _panTask;

        public ScatterPlotService(
            IGetViewExtentTask getViewExtentTask,
            ISetViewExtentTask setViewExtentTask,
            IGetPlotsTask getPlotsTask, 
            IZoomInTask zoomInTask,
            IZoomOutTask zoomOutTask,
            IPanTask panTask)
        {
            _getViewExtentTask = getViewExtentTask;
            _setViewExtentTask = setViewExtentTask;
            _getPlotsTask = getPlotsTask;
            _zoomInTask = zoomInTask;
            _zoomOutTask = zoomOutTask;
            _panTask = panTask;
        }

        public Rect GetViewExtent()
        {
            return _getViewExtentTask.GetViewExtent();
        }

        public void SetViewExtent(Rect viewExtent)
        {
            _setViewExtentTask.SetViewExtent(viewExtent);
        }

        public List<PlotDto> GetPlots()
        {
            return _getPlotsTask.GetPlots();
        }

        public void ZoomIn(Point center)
        {
            _zoomInTask.ZoomIn(center);
        }

        public void ZoomOut(Point center)
        {
            _zoomOutTask.ZoomOut(center);
        }

        public void Pan(Vector vector)
        {
            _panTask.Pan(vector);
        }
    }
}
