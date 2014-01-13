using System.Windows;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Queries
{
    public class GetViewExtentQueryHandler 
        : IQueryHandler<GetViewExtentQuery, Rect>
    {
        private readonly IViewRepository _repository;

        public GetViewExtentQueryHandler(IViewRepository repository)
        {
            _repository = repository;
        }

        public Rect Execute(GetViewExtentQuery query)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            return scatterPlot.GetViewExtent();
        }
    }
}
