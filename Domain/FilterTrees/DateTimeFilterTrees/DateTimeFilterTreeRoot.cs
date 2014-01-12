using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.NullFilterTrees;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Filters.DateTimeFilters;

namespace DataExplorer.Domain.FilterTrees.DateTimeFilterTrees
{
    public class DateTimeFilterTreeRoot : DateTimeFilterTreeNode
    {
        private const int DaysPerMillennium = 365242;
        private const int DaysPerCentury = 36524;
        private const int DaysPerDecade = 3652;
        private const int DaysPerYear = 365;
        private const int DaysPerMonth = 30;
        
        public DateTimeFilterTreeRoot(string name, Column column) 
            : base(name, column, (DateTime) column.Min, (DateTime) column.Max)
        {
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            if (_column.HasNulls)
                yield return new NullFilterTreeLeaf("(Null)", _column);
            
            foreach (var child in CreateDerivedChildren())
                yield return child;
        }

        private IEnumerable<FilterTreeNode> CreateDerivedChildren()
        {
            var timeSpan = _upper - _lower;

            if (timeSpan.Days >= DaysPerMillennium)
                return CreateMillenniumChildren(_lower, _upper);

            if (timeSpan.Days >= DaysPerCentury)
                return new MillenniumFilterTreeNode(null, _column, _lower, _upper).CreateChildren();

            if (timeSpan.Days >= DaysPerDecade)
                return new CenturyFilterTreeNode(null, _column, _lower, _upper).CreateChildren();

            if (timeSpan.Days >= DaysPerYear)
                return new DecadeFilterTreeNode(null, _column, _lower, _upper).CreateChildren();

            if (timeSpan.Days >= DaysPerMonth)
                return new YearFilterTreeNode(null, _column, _lower, _upper).CreateChildren();

            if (timeSpan.Days >= 1)
                return new MonthFilterTreeNode(null, _column, _lower, _upper).CreateChildren();

            if (timeSpan.TotalHours >= 1)
                return new DayFilterTreeNode(null, _column, _lower, _upper).CreateChildren();

            if (timeSpan.TotalMinutes >= 1)
                return new HourFilterTreeNode(null, _column, _lower, _upper).CreateChildren();

            if (timeSpan.TotalSeconds >= 1)
                return new MinuteFilterTreeNode(null, _column, _lower, _upper).CreateChildren();

            return new List<FilterTreeNode>();
        }

        private IEnumerable<FilterTreeNode> CreateMillenniumChildren(DateTime min, DateTime max)
        {
            var lowerMillennium = GetMillennium((DateTime) _column.Min);

            var upperMillennium = GetMillennium((DateTime) _column.Max);

            for (var i = lowerMillennium; i <= upperMillennium; i++)
            {
                var lowerDateTime = CreateLowerDateTime(i);
            
                var upperDateTime = CreateUpperDateTime(i);

                if (!HasValuesInRange(lowerDateTime, upperDateTime))
                    continue;

                var name =  CreateName(i);

                var child = new MillenniumFilterTreeNode(name, _column, lowerDateTime, upperDateTime);

                yield return child;
            }
        }

        private static int GetMillennium(DateTime dateTime)
        {
            return (dateTime.Year / 1000);
        }

        private DateTime CreateLowerDateTime(int millennium)
        {
            return (millennium == 0)
                ? DateTime.MinValue
                : new DateTime((millennium) * 1000, 1, 1);
        }

        private DateTime CreateUpperDateTime(int millennium)
        {
            return (millennium == 9)
               ? DateTime.MaxValue
               : new DateTime((millennium + 1) * 1000, 1, 1).AddTicks(-1);
        }
        
        private static string CreateName(int i)
        {
            return i + "000s";
        }

        public override Filter CreateFilter()
        {
            return _column.HasNulls
                ? new NullableDateTimeFilter(_column, _lower, _upper, true)
                : base.CreateFilter();
        }
    }
}
