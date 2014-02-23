using System;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Layouts.Queries
{
    public class GetColorPaletteQueryHandler 
        : IQueryHandler<GetColorPaletteQuery, ColorPalette>
    {
        private readonly IViewRepository _repository;

        public GetColorPaletteQueryHandler(IViewRepository repository)
        {
            _repository = repository;
        }

        public ColorPalette Execute(GetColorPaletteQuery query)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            var colorPalette = layout.ColorPalette;

            return colorPalette;
        }
    }
}
