using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Application.Rows.Commands
{
    public class SetSelectedRowsCommand : ICommand
    {
        private readonly List<Row> _rows;

        public SetSelectedRowsCommand(List<Row> rows)
        {
            _rows = rows;
        }

        public List<Row> Rows
        {
            get { return _rows; }
        }
    }
}
