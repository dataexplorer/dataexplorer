using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories.BooleanGridLines;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories.DateTimeGridLines;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories.FloatGridLines;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories.IntegerGridLines;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories.StringGridLines;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Axes.Factories
{
    public class GridLineFactory : IGridLineFactory
    {
        private readonly IBooleanGridLineFactory _booleanFactory;
        private readonly IDateTimeGridLineFactory _dateTimeFactory;
        private readonly IFloatGridLineFactory _floatFactory;
        private readonly IIntegerGridLineFactory _integerFactory;
        private readonly IStringGridLineFactory _stringFactory;

        public GridLineFactory(
            IBooleanGridLineFactory booleanFactory,
            IDateTimeGridLineFactory dateTimeFactory,
            IFloatGridLineFactory floatFactory,
            IIntegerGridLineFactory integerFactory,
            IStringGridLineFactory stringFactory)
        {
            _booleanFactory = booleanFactory;
            _dateTimeFactory = dateTimeFactory;
            _floatFactory = floatFactory;
            _integerFactory = integerFactory;
            _stringFactory = stringFactory;
        }

        public IEnumerable<AxisGridLine> Create(Type type, AxisMap map, IEnumerable<object> values, double lower, double upper)
        {
            if (type == typeof(Boolean))
                return _booleanFactory.Create(map, lower, upper);

            if (type == typeof(DateTime))
                return _dateTimeFactory.Create(map, lower, upper);

            if (type == typeof(Double))
                return _floatFactory.Create(map, lower, upper);

            if (type == typeof(Int32))
                return _integerFactory.Create(map, lower, upper);

            if (type == typeof(String))
                return _stringFactory.Create(map, values.ToList(), lower, upper);

            return new List<AxisGridLine>();
        }
    }
}
