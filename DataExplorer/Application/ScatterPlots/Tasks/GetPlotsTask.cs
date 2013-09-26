using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;

namespace DataExplorer.Application.ScatterPlots.Tasks
{
    public class GetPlotsTask : IGetPlotsTask
    {
        private readonly IViewRepository _repository;
        private readonly IScatterPlotAdapter _adapter;

        public GetPlotsTask(
            IViewRepository repository, 
            IScatterPlotAdapter adapter)
        {
            _repository = repository;
            _adapter = adapter;
        }

        public List<PlotDto> GetPlots()
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var plots = scatterPlot.GetPlots();

            var plotDtos = _adapter.Adapt(plots);

            return plotDtos;
        }
    }
}
