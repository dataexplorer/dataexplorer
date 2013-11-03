using System;
using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories.DateTimeAxisGridLines
{
    public class DateTimeAxisGridLineFactory : IDateTimeAxisGridLineFactory
    {
        private const int YearsMaxDateTime = 9998;
        private const int YearsInMillenium = 1000;
        private const int YearsInCentury = 100;
        private const int YearsInDecade = 10;
        private const int DaysInYear = 365;
        private const int DaysInQuarterYear = 90;
        private const int DaysInMonth = 30;
        private const int DaysInWeek = 7;
        private const int SecondsInDay = 86400;
        private const int SecondsInFourHours = 14400;
        private const int SecondsInHour = 3600;
        private const int SecondsInTenMinutes = 600;
        private const int SecondsInMinute = 60;
        private const int SecondsInTenSeconds = 10;
        private const int MillisecondsInSecond = 1000;
        
        private readonly IMinMaxDateTimeAxisGridLineFactory _minMaxFactory;
        private readonly IYearAxisGridLineFactory _yearFactory;
        private readonly IDayAxisGridLineFactory _dayFactory;
        private readonly ISecondAxisGridLineFactory _secondFactory;

        public DateTimeAxisGridLineFactory(
            IMinMaxDateTimeAxisGridLineFactory minMaxFactory,
            IYearAxisGridLineFactory yearFactory,
            IDayAxisGridLineFactory dayFactory,
            ISecondAxisGridLineFactory secondFactory)
        {
            _minMaxFactory = minMaxFactory;
            _yearFactory = yearFactory;
            _dayFactory = dayFactory;
            _secondFactory = secondFactory;
        }

        public IEnumerable<AxisGridLine> Create(IAxisMap map, double lower, double upper)
        {
            var lowerDateTime = (DateTime) map.MapInverse(lower);

            var upperDateTime = (DateTime) map.MapInverse(upper);

            var widthInYears = upperDateTime.Year - lowerDateTime.Year;

            var widthInDays = upperDateTime.Subtract(lowerDateTime).Days;

            var widthInSeconds = upperDateTime.Subtract(lowerDateTime).TotalSeconds;

            var widthInMilliseconds = upperDateTime.Subtract(lowerDateTime).TotalMilliseconds;

            if (widthInYears == YearsMaxDateTime)
                return _minMaxFactory.Create(map);

            if (widthInYears > YearsInMillenium)
                return _yearFactory.Create(map, lowerDateTime, upperDateTime, YearsInMillenium);

            if (widthInYears > YearsInCentury)
                return _yearFactory.Create(map, lowerDateTime, upperDateTime, YearsInCentury);

            if (widthInYears > YearsInDecade)
                return _yearFactory.Create(map, lowerDateTime, upperDateTime, YearsInDecade);

            if (widthInDays > DaysInYear)
                return _yearFactory.Create(map, lowerDateTime, upperDateTime, 1);

            if (widthInDays > DaysInQuarterYear)
                return _dayFactory.CreateQuarters(map, lowerDateTime, upperDateTime);

            if (widthInDays > DaysInMonth)
                return _dayFactory.CreateMonths(map, lowerDateTime, upperDateTime);

            if (widthInDays > DaysInWeek)
                return _dayFactory.CreateWeeks(map, lowerDateTime, upperDateTime);

            if (widthInSeconds > SecondsInDay)
                return _dayFactory.CreateDays(map, lowerDateTime, upperDateTime);

            if (widthInSeconds > SecondsInFourHours)
                return _secondFactory.CreateFourHours(map, lowerDateTime, upperDateTime);
            
            if (widthInSeconds > SecondsInHour)
                return _secondFactory.CreateHours(map, lowerDateTime, upperDateTime);

            if (widthInSeconds > SecondsInTenMinutes)
                return _secondFactory.CreateTenMinutes(map, lowerDateTime, upperDateTime);

            if (widthInSeconds > SecondsInMinute)
                return _secondFactory.CreateMinutes(map, lowerDateTime, upperDateTime);

            if (widthInSeconds > SecondsInTenSeconds)
                return _secondFactory.CreateTenSeconds(map, lowerDateTime, upperDateTime);

            if (widthInMilliseconds > MillisecondsInSecond)
                return _secondFactory.CreateSeconds(map, lowerDateTime, upperDateTime);


            return new List<AxisGridLine>();
        }
    }
}
