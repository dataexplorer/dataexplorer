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
    public class SetViewExtentCommand : ISetViewExtentCommand
    {
        private readonly IViewRepository _repository;

        public SetViewExtentCommand(IViewRepository repository)
        {
            _repository = repository;
        }

        public void SetViewExtent(Rect viewExtent)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            scatterPlot.SetViewExtent(viewExtent);
        }
    }
}
