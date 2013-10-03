using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;

namespace DataExplorer.Application.ScatterPlots.Layouts.Commands
{
    public class ClearLayoutCommand : IClearLayoutCommand
    {
        private readonly IViewRepository _repository;

        public ClearLayoutCommand(IViewRepository repository)
        {
            _repository = repository;
        }

        public void Execute()
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            layout.Clear();
        }
    }
}
