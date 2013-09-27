using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;

namespace DataExplorer.Application.ScatterPlots.Tasks
{
    public class ZoomOutTask : IZoomOutTask
    {
        private const double ZoomOutFactor = 0.11;

        private readonly IViewRepository _repository;

        public ZoomOutTask(IViewRepository repository)
        {
            _repository = repository;
        }

        public void ZoomOut(Point center)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var viewExtent = scatterPlot.GetViewExtent();

            var x = viewExtent.X - (center.X * ZoomOutFactor) - (viewExtent.Width * ZoomOutFactor) / 2;

            var y = viewExtent.Y - (center.Y * ZoomOutFactor) - (viewExtent.Height * ZoomOutFactor) / 2;

            var width = viewExtent.Width + viewExtent.Width * ZoomOutFactor;

            var height = viewExtent.Height + viewExtent.Height * ZoomOutFactor;

            var zoomedViewExtent = new Rect(x, y, width, height);

            scatterPlot.SetViewExtent(zoomedViewExtent);

            DomainEvents.Raise(new ScatterPlotChangedEvent());
        }
    }
}
