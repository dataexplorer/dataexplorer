using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;

namespace DataExplorer.Presentation.Core.Layout
{
    public class LayoutItemViewModel
    {
        private readonly ColumnDto _column;

        public string Name
        {
            get { return _column.Name; }
        }

        public ColumnDto Column
        {
            get { return _column; }
        }

        public LayoutItemViewModel(ColumnDto column)
        {
            _column = column;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is LayoutItemViewModel))
                return false;

            var other = (LayoutItemViewModel) obj;

            return _column.Id == other._column.Id;
        }

        public override int GetHashCode()
        {
            return (_column != null ? _column.GetHashCode() : 0);
        }
    }
}
