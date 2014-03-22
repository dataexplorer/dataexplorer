using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Layouts.General.Commands
{
    public class AutoLayoutColumnCommand : EntityIdCommand
    {
        public AutoLayoutColumnCommand(int id) : base(id)
        {
        }
    }
}
