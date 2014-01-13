using System.Collections.Generic;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Queries
{
    public class GetPlotsQueryHandler : IQueryHandler<GetPlotsQuery, List<PlotDto>>
    {
        private readonly IViewRepository _repository;
        private readonly IScatterPlotAdapter _adapter;

        public GetPlotsQueryHandler(
            IViewRepository repository, 
            IScatterPlotAdapter adapter)
        {
            _repository = repository;
            _adapter = adapter;
        }

        public List<PlotDto> Execute(GetPlotsQuery query)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var plots = scatterPlot.GetPlots();

            var plotDtos = _adapter.Adapt(plots);

            return plotDtos;
        }
    }
}
