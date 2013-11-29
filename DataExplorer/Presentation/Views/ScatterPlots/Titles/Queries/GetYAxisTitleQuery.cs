using System.Windows;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Titles.Renderers;

namespace DataExplorer.Presentation.Views.ScatterPlots.Titles.Queries
{
    public class GetYAxisTitleQuery : IGetYAxisTitleQuery
    {
        private readonly IScatterPlotLayoutService _service;
        private readonly IYAxisTitleRenderer _renderer;

        public GetYAxisTitleQuery(
            IScatterPlotLayoutService service, 
            IYAxisTitleRenderer renderer)
        {
            _service = service;
            _renderer = renderer;
        }

        public CanvasLabel Execute(Size controlSize)
        {
            var column = _service.GetYColumn();

            var text = column != null
                ? column.Name
                : string.Empty;

            return _renderer.Render(controlSize, text);

        }
    }
}
