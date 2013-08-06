using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Domain.Data;
using DataExplorer.Domain.ScatterPlot;
using DataExplorer.Domain.View;

namespace DataExplorer.Application.ScatterPlot
{
    public class ScatterPlotService : IScatterPlotService
    {
        private readonly IDataRepository _dataRepository;
        private readonly IViewRepository _viewRepository;
        private readonly IScatterPlotAdapter _adapter;
        private readonly IScatterPlotRenderer _renderer;

        public ScatterPlotService(
            IDataRepository dataRepository,
            IViewRepository viewRepository,
            IScatterPlotAdapter adapter,
            IScatterPlotRenderer renderer)
        {
            _dataRepository = dataRepository;
            _viewRepository = viewRepository;
            _adapter = adapter;
            _renderer = renderer;
        }

        public Rect GetViewExtent()
        {
            var scatterPlot = _viewRepository.GetScatterPlot();

            return scatterPlot.GetViewExtent();
        }

        public void SetViewExtent(Rect viewExtent)
        {
            var scatterPlot = _viewRepository.GetScatterPlot();

            scatterPlot.SetViewExtent(viewExtent);
        }

        public List<PlotDto> GetPlots()
        {
            var scatterPlot = _viewRepository.GetScatterPlot();

            var plots = scatterPlot.GetPlots();

            var plotDtos = _adapter.Adapt(plots);

            return plotDtos;
        }

        public void UpdateRows()
        {
            var rows = _dataRepository.GetAll();

            var scatterPlot = _viewRepository.GetScatterPlot();

            var plots = _renderer.RenderPlots(rows);

            scatterPlot.SetPlots(plots);
        }
    }
}
