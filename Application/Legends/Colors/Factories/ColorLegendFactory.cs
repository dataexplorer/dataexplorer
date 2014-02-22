using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Legends.Colors.Factories;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Maps.ColorMaps;

namespace DataExplorer.Application.Legends.Factories
{
    public class ColorLegendFactory : IColorLegendFactory
    {
        private readonly IBooleanColorLegendFactory _booleanFactory;
        private readonly IDateTimeColorLegendFactory _dateTimeFactory;
        private readonly IFloatColorLegendFactory _floatFactory;
        private readonly IIntegerColorLegendFactory _integerFactory;
        private readonly IStringColorLegendFactory _stringFactory;

        public ColorLegendFactory(
            IBooleanColorLegendFactory booleanFactory, 
            IDateTimeColorLegendFactory dateTimeFactory, 
            IFloatColorLegendFactory floatFactory, 
            IIntegerColorLegendFactory integerFactory, 
            IStringColorLegendFactory stringFactory)
        {
            _booleanFactory = booleanFactory;
            _dateTimeFactory = dateTimeFactory;
            _floatFactory = floatFactory;
            _integerFactory = integerFactory;
            _stringFactory = stringFactory;
        }

        public IEnumerable<ColorLegendItemDto> Create(Type type, ColorMap map, List<object> values, ColorPalette palette)
        {
            if (type == typeof (Boolean))
                return _booleanFactory.Create(map, values.Cast<bool?>().ToList(), palette);

            if (type == typeof(DateTime))
                return _dateTimeFactory.Create(map, values.Cast<DateTime?>().ToList(), palette);

            if (type == typeof(Double))
                return _floatFactory.Create(map, values.Cast<double?>().ToList(), palette);

            if (type == typeof(Int32))
                return _integerFactory.Create(map, values.Cast<int?>().ToList(), palette);

            if (type == typeof(String))
                return _stringFactory.Create(map, values.Cast<string>().ToList(), palette);

            throw new ArgumentException("Could not create color legend items b");
        }
    }
}
