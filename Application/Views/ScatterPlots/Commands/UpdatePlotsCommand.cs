using System.Linq;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Commands
{
    public class UpdatePlotsCommand : IUpdatePlotsCommand
    {
        private readonly IFilterRepository _filterRepository;
        private readonly IRowRepository _rowRepository;
        private readonly IViewRepository _viewRepository;
        private readonly IScatterPlotRenderer _renderer;

        public UpdatePlotsCommand(
            IFilterRepository filterRepository,
            IRowRepository rowRepository,
            IViewRepository viewRepository,
            IScatterPlotRenderer renderer)
        {
            _rowRepository = rowRepository;
            _viewRepository = viewRepository;
            _renderer = renderer;
            _filterRepository = filterRepository;
        }

        public void UpdatePlots()
        {
            var filters = _filterRepository.GetAll();

            var query = _rowRepository.GetAll();

            var predicates = filters
                .Select(p => p.CreatePredicate())
                .ToList();
            
            predicates.ForEach(p => query = query.Where(p));

            var rows = query.ToList();

            var scatterPlot = _viewRepository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            var plots = _renderer.RenderPlots(rows, layout);

            scatterPlot.SetPlots(plots);
        }
    }
}
