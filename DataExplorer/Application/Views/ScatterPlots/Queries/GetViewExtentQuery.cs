using System.Windows;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Queries
{
    public class GetViewExtentQuery : IGetViewExtentQuery
    {
        private readonly IViewRepository _repository;

        public GetViewExtentQuery(IViewRepository repository)
        {
            _repository = repository;
        }

        public Rect GetViewExtent()
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            return scatterPlot.GetViewExtent();
        }
    }
}
