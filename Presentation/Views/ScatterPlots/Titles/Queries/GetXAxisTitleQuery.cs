using System.Windows;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Titles.Renderers;

namespace DataExplorer.Presentation.Views.ScatterPlots.Titles.Queries
{
    public class GetXAxisTitleQuery : IGetXAxisTitleQuery
    {
        private readonly IScatterPlotLayoutService _service;
        private readonly IXAxisTitleRenderer _renderer;

        public GetXAxisTitleQuery(
            IScatterPlotLayoutService service, 
            IXAxisTitleRenderer renderer)
        {
            _service = service;
            _renderer = renderer;
        }

        public CanvasLabel Execute(Size controlSize)
        {
            var column = _service.GetXColumn();

            var text = column != null
                ? column.Name
                : string.Empty;

            return _renderer.Render(controlSize, text);

        }
    }
}
