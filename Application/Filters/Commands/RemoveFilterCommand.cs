using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Application.Filters.Commands
{
    public class RemoveFilterCommand : FilterCommand
    {
        public RemoveFilterCommand(Filter filter) : base(filter)
        {
        }
    }
}
