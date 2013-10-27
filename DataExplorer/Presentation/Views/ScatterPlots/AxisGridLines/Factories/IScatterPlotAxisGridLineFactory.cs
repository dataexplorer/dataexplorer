using System;
using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories
{
    public interface IScatterPlotAxisGridLineFactory
    {
        IEnumerable<AxisLine> Create(Type type, IAxisMap map, double lower, double upper);
    }
}