using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;

namespace DataExplorer.Application.ScatterPlots.Tasks
{
    public class UpdatePlotsTask : IUpdatePlotsTask
    {
        private readonly IFilterRepository _filterRepository;
        private readonly IRowRepository _rowRepository;
        private readonly IViewRepository _viewRepository;
        private readonly IScatterPlotRenderer _renderer;

        public UpdatePlotsTask(
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
