using System;
using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Factories
{
    public interface IScatterPlotAxisGridLineFactory
    {
        IEnumerable<AxisGridLine> Create(Type type, IAxisMap map, IEnumerable<object> values, double lower, double upper);
    }
}