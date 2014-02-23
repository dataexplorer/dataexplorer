using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Layouts.Size.Queries
{
    public class GetLowerSizeQueryHandler 
        : IQueryHandler<GetLowerSizeQuery, double>
    {
        private readonly IViewRepository _repository;

        public GetLowerSizeQueryHandler(IViewRepository repository)
        {
            _repository = repository;
        }

        public double Execute(GetLowerSizeQuery query)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            return layout.LowerSize;
        }
    }
}
