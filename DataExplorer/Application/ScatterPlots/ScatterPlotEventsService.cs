using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;

namespace DataExplorer.Application.ScatterPlots
{
    public class ScatterPlotEventsService : IHandler<ProjectOpenedEvent>
    {
        private readonly IRowRepository _rowRepository;
        private readonly IViewRepository _viewRepository;
        private readonly IScatterPlotRenderer _renderer;

        public ScatterPlotEventsService(
            IRowRepository rowRepository,
            IViewRepository viewRepository,
            IScatterPlotRenderer renderer)
        {
            _rowRepository = rowRepository;
            _viewRepository = viewRepository;
            _renderer = renderer;
        }

        private void UpdatePlots()
        {
            var rows = _rowRepository.GetAll();

            var scatterPlot = _viewRepository.GetScatterPlot();

            var plots = _renderer.RenderPlots(rows);

            scatterPlot.SetPlots(plots);
        }

        public void Handle(ProjectOpenedEvent args)
        {
            UpdatePlots();
        }
    }
}
