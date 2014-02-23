using System;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Layouts.Location.Commands
{
    public class SetXColumnCommand : EntityIdCommand
    {
        public SetXColumnCommand(int id) : base(id)
        {
        }
    }
}
