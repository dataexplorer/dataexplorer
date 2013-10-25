using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Renderers;

namespace DataExplorer.Presentation.Views.ScatterPlots.Queries
{
    public class GetScatterPlotXAxisTitleQuery : IGetScatterPlotXAxisTitleQuery
    {
        private readonly IScatterPlotLayoutService _service;
        private readonly IScatterPlotXAxisTitleRenderer _renderer;

        public GetScatterPlotXAxisTitleQuery(
            IScatterPlotLayoutService service, 
            IScatterPlotXAxisTitleRenderer renderer)
        {
            _service = service;
            _renderer = renderer;
        }

        public ICanvasItem Execute(Size controlSize)
        {
            var column = _service.GetXColumn();

            var text = column != null
                ? column.Name
                : string.Empty;

            return _renderer.Render(controlSize, text);

        }
    }
}
