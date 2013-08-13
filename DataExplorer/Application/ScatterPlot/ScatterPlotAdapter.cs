using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Application.ScatterPlot
{
    public class ScatterPlotAdapter : IScatterPlotAdapter
    {
        public List<PlotDto> Adapt(List<Plot> plots)
        {
            var dtos = new List<PlotDto>();
            foreach (var plot in plots)
            {
                var dto = new PlotDto();
                dto.X = plot.X;
                dto.Y = plot.Y;
                dtos.Add(dto);
            }
            return dtos;
        }
    }
}
