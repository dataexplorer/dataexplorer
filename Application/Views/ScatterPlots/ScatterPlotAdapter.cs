using System.Collections.Generic;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots
{
    public class ScatterPlotAdapter : IScatterPlotAdapter
    {
        public List<PlotDto> Adapt(List<Plot> plots)
        {
            var dtos = new List<PlotDto>();
            foreach (var plot in plots)
            {
                var dto = new PlotDto();
                dto.Id = plot.Id;
                dto.X = plot.X;
                dto.Y = plot.Y;
                dto.Color = plot.Color;
                dtos.Add(dto);
            }
            return dtos;
        }
    }
}
