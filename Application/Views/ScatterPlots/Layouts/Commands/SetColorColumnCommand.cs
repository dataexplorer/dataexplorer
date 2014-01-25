using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Views.ScatterPlots.Layouts.Commands
{
    public class SetColorColumnCommand : EntityIdCommand
    {
        public SetColorColumnCommand(int id) : base(id)
        {
            
        }
    }
}
