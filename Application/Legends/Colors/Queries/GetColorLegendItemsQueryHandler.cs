using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Legends.Factories;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Legends.Queries
{
    public class GetColorLegendItemsQueryHandler 
        : IQueryHandler<GetColorLegendItemsQuery, List<ColorLegendItemDto>>
    {
        private readonly IViewRepository _viewRepository;
        private readonly IMapFactory _mapFactory;
        private readonly IColorLegendItemFactory _itemFactory;

        public GetColorLegendItemsQueryHandler(
            IViewRepository viewRepository, 
            IMapFactory mapFactory,
            IColorLegendItemFactory itemFactory)
        {
            _viewRepository = viewRepository;
            _mapFactory = mapFactory;
            _itemFactory = itemFactory;
        }

        public List<ColorLegendItemDto> Execute(GetColorLegendItemsQuery query)
        {
            var scatterPlot = _viewRepository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            var column = layout.ColorColumn;

            if (column == null)
                return new List<ColorLegendItemDto>();

            var type = column.Type;

            var palette = layout.ColorPalette;

            var map = _mapFactory.CreateColorMap(column, palette);
            
            var values = column.Values
                .Distinct()
                .ToList();
            
            var items = _itemFactory.Create(type,  map, values, palette);

            return items.ToList();
        }
    }
}
