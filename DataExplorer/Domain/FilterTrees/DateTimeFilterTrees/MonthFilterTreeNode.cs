using System;
using System.Collections.Generic;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.DateTimeFilterTrees
{
    public class MonthFilterTreeNode : DateTimeFilterTreeNode
    {
        public MonthFilterTreeNode(string name, Column column, DateTime lower, DateTime upper)
            : base(name, column, lower, upper)
        {
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            var year = _lower.Year;

            var month = _lower.Month;

            var lowerDay = _lower.Day;

            var upperDay = _upper.Day;

            for (var i = lowerDay; i <= upperDay; i++)
            {
                var lowerDateTime = CreateLowerDateTime(year, month, i);

                var upperDateTime = CreateUpperDateTime(year, month, i);

                if (!HasValuesInRange(lowerDateTime, upperDateTime))
                    continue;

                var name = CreateName(lowerDateTime);

                var child = new DayFilterTreeNode(name, _column, lowerDateTime, upperDateTime);

                yield return child;
            }
        }

        private DateTime CreateLowerDateTime(int year, int month, int day)
        {
            return (year == 1 && month == 1 && day == 1)
                ? DateTime.MinValue
                : new DateTime(year, month, day);
        }

        private DateTime CreateUpperDateTime(int year, int month, int day)
        {
            return (year == 9999 && month == 12 && day == 31)
               ? DateTime.MaxValue
               : new DateTime(year, month, day)
                    .AddDays(1)
                    .AddTicks(-1);
        }

        private static string CreateName(DateTime dateTime)
        {
            return dateTime.ToString("dd");
        }
    }
}
