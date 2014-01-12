using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Filters.IntegerFilters;

namespace DataExplorer.Domain.FilterTrees.IntegerFilterTrees
{
    public class IntegerFilterTreeNode : FilterTreeNode
    {
        private const int EquiValueCount = 10;

        protected readonly int _lower;
        protected readonly int _upper;

        public IntegerFilterTreeNode(string name, Column column, int lower, int upper) 
            : base(name, column)
        {
            _lower = lower;
            _upper = upper;
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            var values = GetDistinctValuesInRange(_lower, _upper).ToList();

            return values.Count() <= EquiValueCount
                ? CreateLeaves(values)
                : CreateNodes(values);
        }

        public override Filter CreateFilter()
        {
            return new IntegerFilter(_column, _lower, _upper);
        }

        private IEnumerable<FilterTreeNode> CreateLeaves(IEnumerable<int> values)
        {
            var leaves = values.Select(CreateLeaf);

            return leaves;
        }

        private FilterTreeNode CreateLeaf(int value)
        {
            var name = CreateLeafName(value);

            var leaf = new IntegerFilterTreeLeaf(name, _column, value);

            return leaf;
        }

        private string CreateLeafName(int value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        private IEnumerable<FilterTreeNode> CreateNodes(List<int> values)
        {
            var interval = Math.Max((double) values.Count() / EquiValueCount, 1d);

            for (int i = 0; i < EquiValueCount; i++)
            {
                var lowerIndex = (int)(interval * i);
                var upperIndex = i == EquiValueCount - 1
                    ? values.Count() - 1
                    : (int)(interval * (i + 1) - 1);

                var lowerValue = values[lowerIndex];
                var upperValue = values[upperIndex];

                var name = CreateNodeName(lowerValue, upperValue);

                yield return new IntegerFilterTreeNode(name, _column, lowerValue, upperValue);
            }
        }

        private string CreateNodeName(double lowerValue, double upperValue)
        {
            return lowerValue.ToString(CultureInfo.InvariantCulture)
                + " - "
                + upperValue.ToString(CultureInfo.InvariantCulture);
        }

        // TODO: See if I can refactor out this duplication
        private IEnumerable<T> GetDistinctValuesInRange<T>(T low, T high)
            where T : IComparable
        {
            return _column.Values
                .Where(p => p != null)
                .Cast<T>()
                .Where(p => p.CompareTo(low) >= 0)
                .Where(p => p.CompareTo(high) <= 0)
                .Distinct();
        }
    }
}
