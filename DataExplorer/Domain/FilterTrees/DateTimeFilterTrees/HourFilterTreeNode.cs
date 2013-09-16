using System;
using System.Collections.Generic;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.DateTimeFilterTrees
{
    public class HourFilterTreeNode : DateTimeFilterTreeNode
    {
        public HourFilterTreeNode(string name, Column column, DateTime lower, DateTime upper) 
            : base(name, column, lower, upper)
        {
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            var children = new List<FilterTreeNode>();

            var year = _lower.Year;

            var month = _lower.Month;

            var day = _lower.Day;

            var hour = _lower.Hour;

            var lowerMinute = _lower.Minute;

            var upperMinute = _upper.Minute;

            for (var i = lowerMinute; i <= upperMinute; i++)
            {
                var lowerDateTime = CreateLowerDateTime(year, month, day, hour, i);

                var upperDateTime = CreateUpperDateTime(year, month, day, hour, i);

                if (!HasValuesInRange(lowerDateTime, upperDateTime))
                    continue;

                var name = CreateName(lowerDateTime);

                var child = new MinuteFilterTreeNode(name, _column, lowerDateTime, upperDateTime);

                children.Add(child);
            }

            return children;
        }

        private DateTime CreateLowerDateTime(int year, int month, int day, int hour, int minute)
        {
            return (year == 1 && month == 1 && day == 1 
                    && hour == 0 && minute == 0)
                ? DateTime.MinValue
                : new DateTime(year, month, day, hour, minute, 0);
        }

        private DateTime CreateUpperDateTime(int year, int month, int day, int hour, int minute)
        {
            return (year == 9999 && month == 12 && day == 31 
                    && hour == 23 && minute == 59)
               ? DateTime.MaxValue
               : new DateTime(year, month, day, hour, minute, 0)
                    .AddMinutes(1)
                    .AddTicks(-1);
        }

        private static string CreateName(DateTime dateTime)
        {
            return dateTime.ToString("hh:mm");
        }
    }
}
