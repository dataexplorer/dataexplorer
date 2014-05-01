using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Legends.Colors.Factories;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Legends.Colors.Queries
{
    public class GetColorLegendItemsQueryHandler 
        : IQueryHandler<GetColorLegendItemsQuery, List<ColorLegendItemDto>>
    {
        private readonly IViewRepository _viewRepository;
        private readonly IMapFactory _mapFactory;
        private readonly IColorLegendFactory _legendFactory;

        public GetColorLegendItemsQueryHandler(
            IViewRepository viewRepository, 
            IMapFactory mapFactory,
            IColorLegendFactory legendFactory)
        {
            _viewRepository = viewRepository;
            _mapFactory = mapFactory;
            _legendFactory = legendFactory;
        }

        public List<ColorLegendItemDto> Execute(GetColorLegendItemsQuery query)
        {
            var scatterPlot = _viewRepository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            var column = layout.ColorColumn;

            if (column == null)
                return new List<ColorLegendItemDto>();

            var type = column.DataType;

            var palette = layout.ColorPalette;

            var map = _mapFactory.CreateColorMap(column, palette, layout.ColorSortOrder);
            
            var items = _legendFactory.Create(type,  map, column.Values, palette);

            return items.ToList();
        }
    }
}
