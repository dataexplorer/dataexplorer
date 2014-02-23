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
    public class GetUpperSizeQueryHandler 
        : IQueryHandler<GetUpperSizeQuery, double>
    {
        private readonly IViewRepository _repository;

        public GetUpperSizeQueryHandler(IViewRepository repository)
        {
            _repository = repository;
        }

        public double Execute(GetUpperSizeQuery query)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            return layout.UpperSize;
        }
    }
}
