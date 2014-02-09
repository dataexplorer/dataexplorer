using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Domain;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Layouts.Queries
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
