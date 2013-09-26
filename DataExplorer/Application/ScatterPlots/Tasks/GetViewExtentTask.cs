using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;

namespace DataExplorer.Application.ScatterPlots.Tasks
{
    public class GetViewExtentTask : IGetViewExtentTask
    {
        private readonly IViewRepository _repository;

        public GetViewExtentTask(IViewRepository repository)
        {
            _repository = repository;
        }

        public Rect GetViewExtent()
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            return scatterPlot.GetViewExtent();
        }
    }
}
