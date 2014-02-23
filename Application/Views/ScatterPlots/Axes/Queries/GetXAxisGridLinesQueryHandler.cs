using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Maps.Queries;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories;
using DataExplorer.Application.Views.ScatterPlots.Queries;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Axes.Queries
{
    public class GetXAxisGridLinesQueryHandler 
        : IQueryHandler<GetXAxisGridLinesQuery, List<AxisGridLine>>
    {
        private readonly IViewRepository _viewRepository;
        private readonly IMapFactory _mapFactory;
        private readonly IGridLineFactory _gridLineFactory;

        public GetXAxisGridLinesQueryHandler(
            IViewRepository viewRepository, 
            IMapFactory mapFactory,
            IGridLineFactory gridLineFactory)
        {
            _viewRepository = viewRepository;
            _mapFactory = mapFactory;
            _gridLineFactory = gridLineFactory;
        }

        public List<AxisGridLine> Execute(GetXAxisGridLinesQuery query)
        {
            var view = _viewRepository.Get<ScatterPlot>();

            var viewExtent = view.GetViewExtent();

            var layout = view.GetLayout();

            var column = layout.XAxisColumn;

            if (column == null)
                return new List<AxisGridLine>();

            var map = _mapFactory.CreateAxisMap(column, 0d, 1d);

            var values = column.Values
                .Distinct()
                .ToList();

            var axisLines = _gridLineFactory.Create(column.Type, map, values, viewExtent.Left, viewExtent.Right);

            return axisLines.ToList();
        }
    }
}
