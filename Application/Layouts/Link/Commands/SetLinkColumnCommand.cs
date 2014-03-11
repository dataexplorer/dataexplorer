using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Layouts.Link.Commands
{
    public class SetLinkColumnCommand : EntityIdCommand
    {
        public SetLinkColumnCommand(int id) : base(id)
        {
        }
    }
}
