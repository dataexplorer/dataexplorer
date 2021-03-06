﻿using System;
using System.Collections.Generic;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Axes.Factories.DateTimeGridLines
{
    public class SecondAxisGridLineFactory : ISecondAxisGridLineFactory
    {
        public IEnumerable<AxisGridLine> CreateFourHours(AxisMap map, DateTime lower, DateTime upper)
        {
            var startTime = lower.Date;

            var endTime = upper;

            for (var date = startTime; date <= endTime; date = date.AddHours(4))
                yield return CreateAxisGridLine(map, date);
        }

        public IEnumerable<AxisGridLine> CreateHours(AxisMap map, DateTime lower, DateTime upper)
        {
            var startTime = lower.Date.AddHours(lower.Hour);

            var endTime = upper;

            for (var date = startTime; date <= endTime; date = date.AddHours(1))
                yield return CreateAxisGridLine(map, date);
        }

        public IEnumerable<AxisGridLine> CreateTenMinutes(AxisMap map, DateTime lower, DateTime upper)
        {
            var startTime = lower.Date.AddHours(lower.Hour);

            var endTime = upper;

            for (var date = startTime; date <= endTime; date = date.AddMinutes(10))
                yield return CreateAxisGridLine(map, date);
        }

        public IEnumerable<AxisGridLine> CreateMinutes(AxisMap map, DateTime lower, DateTime upper)
        {
            var startTime = lower.Date
                .AddHours(lower.Hour)
                .AddMinutes(lower.Minute);

            var endTime = upper;

            for (var date = startTime; date <= endTime; date = date.AddMinutes(1))
                yield return CreateAxisGridLine(map, date);
        }

        public IEnumerable<AxisGridLine> CreateTenSeconds(AxisMap map, DateTime lower, DateTime upper)
        {
            var startTime = lower.Date
                .AddHours(lower.Hour)
                .AddMinutes(lower.Minute);

            var endTime = upper;

            for (var date = startTime; date <= endTime; date = date.AddSeconds(10))
                yield return CreateAxisGridLine(map, date);
        }

        public IEnumerable<AxisGridLine> CreateSeconds(AxisMap map, DateTime lower, DateTime upper)
        {
            var startTime = lower.Date
                .AddHours(lower.Hour)
                .AddMinutes(lower.Minute)
                .AddSeconds(lower.Second);

            var endTime = upper;

            for (var date = startTime; date <= endTime; date = date.AddSeconds(1))
                yield return CreateAxisGridLine(map, date);
        }


        // TODO: This is duplicated across multiple classes... must refactor
        private static AxisGridLine CreateAxisGridLine(AxisMap map, DateTime value)
        {
            var position = map.Map(value);

            var line = new AxisGridLine()
            {
                LabelName = value.ToLongTimeString(),
                Position = position.GetValueOrDefault()
            };

            return line;
        }
    }
}
