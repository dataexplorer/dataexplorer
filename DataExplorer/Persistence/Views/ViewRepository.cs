using System;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;

namespace DataExplorer.Persistence.Views
{
    public class ViewRepository : IViewRepository
    {
        private readonly IDataContext _viewContext;

        public ViewRepository(IDataContext viewContext)
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
