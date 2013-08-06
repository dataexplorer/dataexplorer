using System;
using DataExplorer.Domain.ScatterPlot;
using DataExplorer.Domain.View;

namespace DataExplorer.Persistence.View
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
    }
}
