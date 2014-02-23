using System;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Layouts.Commands
{
    public class SetXColumnCommand : EntityIdCommand
    {
        public SetXColumnCommand(int id) : base(id)
        {
        }
    }
}
