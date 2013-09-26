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
    public class PanTask : IPanTask
    {
        private readonly IViewRepository _repository;

        public PanTask(IViewRepository repository)
        {
            _repository = repository;
        }

        public void Pan(Vector vector)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var viewExtent = scatterPlot.GetViewExtent();

            viewExtent.X += vector.X;

            viewExtent.Y += vector.Y;

            scatterPlot.SetViewExtent(viewExtent);

            DomainEvents.Raise(new ScatterPlotChangedEvent());
        }
    }
}
