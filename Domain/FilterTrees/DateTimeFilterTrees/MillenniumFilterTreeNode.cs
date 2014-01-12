using System;
using System.Collections.Generic;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.DateTimeFilterTrees
{
    public class MillenniumFilterTreeNode : DateTimeFilterTreeNode
    {
        public MillenniumFilterTreeNode(string name, Column column, DateTime lower, DateTime upper) 
            : base(name, column, lower, upper)
        {
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            var lowerCentury = GetCentury(_lower);

            var upperCentury = GetCentury(_upper);

            for (var i = lowerCentury; i <= upperCentury; i++)
            {
                var lowerDateTime = CreateLowerDateTime(i);

                var upperDateTime = CreateUpperDateTime(i);

                if (!HasValuesInRange(lowerDateTime, upperDateTime))
                    continue;

                var name = CreateName(i);

                var child = new CenturyFilterTreeNode(name, _column, lowerDateTime, upperDateTime);

                yield return child;
            }
        }

        private static int GetCentury(DateTime dateTime)
        {
            return (dateTime.Year / 100);
        }

        private DateTime CreateLowerDateTime(int century)
        {
            return (century == 0)
                ? DateTime.MinValue
                : new DateTime((century) * 100, 1, 1);
        }

        private DateTime CreateUpperDateTime(int century)
        {
            return (century == 99)
               ? DateTime.MaxValue
               : new DateTime((century + 1) * 100, 1, 1).AddTicks(-1);
        }

        private static string CreateName(int i)
        {
            return i + "00s";
        }
    }
}
