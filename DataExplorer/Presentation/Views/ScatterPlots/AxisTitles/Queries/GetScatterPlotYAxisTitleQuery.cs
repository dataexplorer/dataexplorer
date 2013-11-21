using System.Windows;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.AxisTitles.Renderers;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisTitles.Queries
{
    public class GetScatterPlotYAxisTitleQuery : IGetScatterPlotYAxisTitleQuery
    {
        private readonly IScatterPlotLayoutService _service;
        private readonly IScatterPlotYAxisTitleRenderer _renderer;

        public GetScatterPlotYAxisTitleQuery(
            IScatterPlotLayoutService service, 
            IScatterPlotYAxisTitleRenderer renderer)
        {
            _service = service;
            _renderer = renderer;
        }

        public CanvasItem Execute(Size controlSize)
        {
            var column = _service.GetYColumn();

            var text = column != null
                ? column.Name
                : string.Empty;

            return _renderer.Render(controlSize, text);

        }
    }
}
