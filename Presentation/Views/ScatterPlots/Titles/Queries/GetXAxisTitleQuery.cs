using System.Windows;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Queries;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Titles.Renderers;

namespace DataExplorer.Presentation.Views.ScatterPlots.Titles.Queries
{
    public class GetXAxisTitleQuery : IGetXAxisTitleQuery
    {
        private readonly IQueryBus _queryBus;
        private readonly IXAxisTitleRenderer _renderer;

        public GetXAxisTitleQuery(
            IQueryBus queryBus, 
            IXAxisTitleRenderer renderer)
        {
            _queryBus = queryBus;
            _renderer = renderer;
        }

        public CanvasLabel Execute(Size controlSize)
        {
            var column = _queryBus.Execute(new GetXColumnQuery());

            var text = column != null
                ? column.Name
                : string.Empty;

            return _renderer.Render(controlSize, text);

        }
    }
}
