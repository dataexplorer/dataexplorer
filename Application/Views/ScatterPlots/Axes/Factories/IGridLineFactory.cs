using System;
using System.Collections.Generic;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Axes.Factories
{
    public interface IGridLineFactory
    {
        IEnumerable<AxisGridLine> Create(Type type, AxisMap map, IEnumerable<object> values, double lower, double upper);
    }
}