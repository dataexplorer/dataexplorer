using System.Windows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;

namespace DataExplorer.Application.ScatterPlots.Queries
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
