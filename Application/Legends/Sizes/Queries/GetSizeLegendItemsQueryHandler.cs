using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Legends.Sizes.Factories;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Legends.Sizes.Queries
{
    public class GetSizeLegendItemsQueryHandler : IQueryHandler<GetSizeLegendItemsQuery, List<SizeLegendItemDto>>
    {
        private readonly IViewRepository _repository;
        private readonly IMapFactory _mapFactory;
        private readonly ISizeLegendFactory _legendFactory;

        public GetSizeLegendItemsQueryHandler(
            IViewRepository repository, 
            IMapFactory mapFactory, 
            ISizeLegendFactory legendFactory)
        {
            _repository = repository;
            _mapFactory = mapFactory;
            _legendFactory = legendFactory;
        }

        public List<SizeLegendItemDto> Execute(GetSizeLegendItemsQuery query)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            var column = layout.SizeColumn;

            if (column == null)
                return new List<SizeLegendItemDto>();

            var type = column.DataType;

            var map = _mapFactory.CreateSizeMap(column, layout.LowerSize, layout.UpperSize, layout.SizeSortOrder);

            var items = _legendFactory.Create(type, map, column.Values, layout.LowerSize, layout.UpperSize);

            return items.ToList();
        }
    }
}
