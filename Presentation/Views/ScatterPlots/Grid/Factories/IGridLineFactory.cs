using System;
using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Factories
{
    public interface IGridLineFactory
    {
        IEnumerable<AxisGridLine> Create(Type type, AxisMap map, IEnumerable<object> values, double lower, double upper);
    }
}