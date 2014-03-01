using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Maps.SizeMaps;

namespace DataExplorer.Application.Legends.Sizes.Factories
{
    public class SizeLegendFactory : ISizeLegendFactory
    {
        private readonly IBooleanSizeLegendFactory _booleanFactory;
        private readonly IDateTimeSizeLegendFactory _dateTimeFactory;
        private readonly IFloatSizeLegendFactory _floatFactory;
        private readonly IIntegerSizeLegendFactory _integerFactory;
        private readonly IStringSizeLegendFactory _stringFactory;

        public SizeLegendFactory(
            IBooleanSizeLegendFactory booleanFactory, 
            IDateTimeSizeLegendFactory dateTimeFactory, 
            IFloatSizeLegendFactory floatFactory, 
            IIntegerSizeLegendFactory integerFactory, 
            IStringSizeLegendFactory stringFactory)
        {
            _booleanFactory = booleanFactory;
            _dateTimeFactory = dateTimeFactory;
            _floatFactory = floatFactory;
            _integerFactory = integerFactory;
            _stringFactory = stringFactory;
        }

        public IEnumerable<SizeLegendItemDto> Create(Type type, SizeMap map, List<object> values, double lowerSize, double upperSize)
        {
            if (type == typeof(Boolean))
                return _booleanFactory.Create(map, values.Cast<bool?>().ToList(), lowerSize, upperSize);

            if (type == typeof(DateTime))
                return _dateTimeFactory.Create(map, values.Cast<DateTime?>().ToList(), lowerSize, upperSize);

            if (type == typeof(Double))
                return _floatFactory.Create(map, values.Cast<double?>().ToList(), lowerSize, upperSize);

            if (type == typeof(Int32))
                return _integerFactory.Create(map, values.Cast<int?>().ToList(), lowerSize, upperSize);

            if (type == typeof(String))
                return _stringFactory.Create(map, values.Cast<string>().ToList(), lowerSize, upperSize);

            throw new ArgumentException("Could not create color legend items because data type was not recognized");
        }
    }
}
