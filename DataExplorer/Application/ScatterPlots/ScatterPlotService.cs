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
        private readonly IPanTask _panTask;

        public ScatterPlotService(
            IGetViewExtentTask getViewExtentTask,
            ISetViewExtentTask setViewExtentTask,
            IGetPlotsTask getPlotsTask, 
            IPanTask panTask)
        {
            _getViewExtentTask = getViewExtentTask;
            _setViewExtentTask = setViewExtentTask;
            _getPlotsTask = getPlotsTask;
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

        public void Pan(Vector vector)
        {
            _panTask.Pan(vector);
        }
    }
}
