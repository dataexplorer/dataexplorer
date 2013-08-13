using System;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;

namespace DataExplorer.Persistence.Views
{
    public class ViewRepository : IViewRepository
    {
        private readonly IViewContext _viewContext;

        public ViewRepository(IViewContext viewContext)
        {
            _viewContext = viewContext;
        }

        public IScatterPlot GetScatterPlot()
        {
            return _viewContext.ScatterPlot;
        }

        public void Add(IScatterPlot view)
        {
            _viewContext.ScatterPlot = view;
        }
    }
}
