using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Filters.StringFilters;

namespace DataExplorer.Domain.FilterTrees.StringFilterTrees
{
    public class StringFilterTreeNode : FilterTreeNode
    {
        private const int EquiValueCount = 10;
        private const int MaxDepth = 3;
        private const int StartChar = 32;
        private const int EndChar = 96;

        protected readonly string _value;
        private readonly int _depth;

        public StringFilterTreeNode(string name, Column column, string value, int depth) 
            : base(name, column)
        {
            _value = value;
            _depth = depth;
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            var values = GetDistinctValuesWhereStartsWith(_value).ToList();

            return ShouldCreateLeaves(values)
                ? CreateLeaves(values)
                : CreateNodes(values);
        }

        public override Filter CreateFilter()
        {
            return new StringFilter(_column, _value);
        }

        private bool ShouldCreateLeaves(List<string> values)
        {
            return values.Count() <= EquiValueCount 
                || _depth >= MaxDepth;
        }

        private IEnumerable<FilterTreeNode> CreateLeaves(IEnumerable<string> values)
        {
            return values.Select(p => new StringFilterTreeLeaf(p, _column, p, _depth + 1));
        }

        private IEnumerable<FilterTreeNode> CreateNodes(List<string> values)
        {
            for (var c = StartChar; c <= EndChar; c++)
            {
                var newValue = _value + (char) c;

                if (values.Any(p => p.StartsWith(newValue, StringComparison.OrdinalIgnoreCase)))
                    yield return new StringFilterTreeNode(newValue, _column, newValue, _depth + 1);
            }
        }

        private IEnumerable<string> GetDistinctValuesWhereStartsWith(string match)
        {
            return _column.Values
                .Cast<string>()
                .Where(p => p.StartsWith(match, 
                    StringComparison.OrdinalIgnoreCase))
                .Distinct();
        }
    }
}
